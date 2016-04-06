using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using SteamKit2;
using System.Timers;
using SteamKit2.Internal;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Net;

namespace HourBoostr
{
    class Bot
    {
        /// <summary>
        /// Enum for bot state
        /// </summary>
        public enum BotState
        {
            LoggedOut,
            LoggedIn
        }


        /// <summary>
        /// Represents if the bot is in running state
        /// </summary>
        public bool mIsRunning { get; set; }


        /// <summary>
        /// State of bot status
        /// </summary>
        public BotState mBotState { get; private set; }


        /// <summary>
        /// The steam session of the bot
        /// We can instance this on load
        /// </summary>
        public Steam mSteam { get; set; } = new Steam();


        /// <summary>
        /// Bot thread
        /// </summary>
        private BackgroundWorker mBotThread;


        /// <summary>
        /// Information for this account
        /// </summary>
        public Config.AccountInfo mInfo { get; private set; }


        /// <summary>
        /// Application settings
        /// </summary>
        private Config.Settings mSettings { get; set; }


        /// <summary>
        /// Timer to simulate stopping and restarting a game
        /// </summary>
        private System.Timers.Timer mGameTimer = new System.Timers.Timer();


        /// <summary>
        /// Main initializer for each account
        /// </summary>
        /// <param name="info">Account info</param>
        public Bot(Config.AccountInfo info, Config.Settings settings)
        {
            /*If a password isn't set we'll ask for user input*/
            if (string.IsNullOrEmpty(info.Password))
            {
                Console.WriteLine("Enter password for account '{0}'", info.Username);
                info.Password = Password.ReadPassword();
            }

            /*Assign bot info*/
            mSteam.loginDetails = new SteamUser.LogOnDetails()
            {
                Username = info.Username,
                Password = info.Password,
                ShouldRememberPassword = true
            };
            mInfo = info;
            mSettings = settings;
            mSteam.games = info.Games;
            mSteam.sentryPath = Path.Combine(Application.StartupPath, string.Format("Sentryfiles\\{0}.sentry", info.Username));

            /*Assign clients*/
            mSteam.client = new SteamClient();
            mSteam.callbackManager = new CallbackManager(mSteam.client);
            mSteam.user = mSteam.client.GetHandler<SteamUser>();
            mSteam.friends = mSteam.client.GetHandler<SteamFriends>();

            /*Subscribe to Callbacks*/
            mSteam.callbackManager.Subscribe<SteamClient.ConnectedCallback>(OnConnected);
            mSteam.callbackManager.Subscribe<SteamClient.DisconnectedCallback>(OnDisconnected);
            mSteam.callbackManager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
            mSteam.callbackManager.Subscribe<SteamUser.UpdateMachineAuthCallback>(OnMachineAuth);
            mSteam.callbackManager.Subscribe<SteamUser.LoginKeyCallback>(OnLoginKey);

            /*Connect to Steam*/
            Connect();

            /*Start Callback thread*/
            mBotThread = new BackgroundWorker { WorkerSupportsCancellation = true };
            mBotThread.DoWork += BackgroundWorkerOnDoWork;
            mBotThread.RunWorkerCompleted += BackgroundWorkerOnRunWorkerCompleted;
            mBotThread.RunWorkerAsync();
        }


        /// <summary>
        /// Connect to Steam
        /// </summary>
        private void Connect()
        {
            mIsRunning = true;
            Print("Connecting to steam ...", mInfo.Username);
            SteamDirectory.Initialize().Wait();
            mSteam.client.Connect();
        }


        /// <summary>
        /// Writes to console with time and username
        /// </summary>
        /// <param name="str"></param>
        private void Print(string str, params object[] args)
        {
            string time = DateTime.Now.ToString("d/M/yyyy HH:mm:ss");
            Console.WriteLine("{0} {1} - {2}", time, mSteam.loginDetails.Username, string.Format(str, args));
        }


        /// <summary>
        /// Backgroundworker for callbacks
        /// </summary>
        private void BackgroundWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            while (!mBotThread.CancellationPending)
            {
                try
                {
                    mSteam.callbackManager.RunCallbacks();
                    Thread.Sleep(500);
                }
                catch (WebException ex)
                {
                    Print("Webexception for callbacks: ", ex.Message);
                    Thread.Sleep(10000);
                }
                catch (Exception ex)
                {
                    Print("Exception for callbacks: ", ex.Message);
                    Thread.Sleep(10000);
                }
            }
        }


        /// <summary>
        /// Backgroundworker callback complete
        /// </summary>
        private void BackgroundWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            if (runWorkerCompletedEventArgs.Error != null)
            {
                Exception ex = runWorkerCompletedEventArgs.Error;
                Print("Unhandled exception in callback bgw: ", ex.Message);
            }

            Print("Bot stopped!");
            mIsRunning = false;
        }


        /// <summary>
        /// OnConnected Callback
        /// Fires when Client connects to Steam
        /// </summary>
        /// <param name="callback"></param>
        private void OnConnected(SteamClient.ConnectedCallback callback)
        {
            /*Login - NOT OK*/
            if(callback.Result != EResult.OK)
            {
                Print("Error: {0}", callback.Result);
                mIsRunning = false;
                return;
            }

            /*Set sentry hash*/
            byte[] sentryHash = null;
            if (File.Exists(mSteam.sentryPath))
            {
                byte[] sentryFile = File.ReadAllBytes(mSteam.sentryPath);
                sentryHash = CryptoHelper.SHAHash(sentryFile);
            }

            /*Attempt to login*/
            Print("Connected! Logging in...");
            mSteam.loginDetails.SentryFileHash = sentryHash;
            mSteam.user.LogOn(mSteam.loginDetails);
        }


        /// <summary>
        /// OnDisconnected Callback
        /// Fires when Client disconnects from Steam
        /// Will also fire when setting up an account to re-auth
        /// </summary>
        /// <param name="callback"></param>
        private void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            mBotState = BotState.LoggedOut;
            if (mIsRunning)
            {
                Print("Reconnecting in 3s...");
                Thread.Sleep(3000);
                Connect();
            }
        }


        /// <summary>
        /// OnMachineAuth Callback
        /// Fires when User is authenticating the Steam account
        /// </summary>
        /// <param name="callback"></param>
        private void OnMachineAuth(SteamUser.UpdateMachineAuthCallback callback)
        {
            /*Handles Sentry file for auth*/
            int fileSize;
            byte[] sentryHash;
            using (var fs = File.Open(mSteam.sentryPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                /*Fetch data*/
                fs.Seek(callback.Offset, SeekOrigin.Begin);
                fs.Write(callback.Data, 0, callback.BytesToWrite);
                fileSize = (int)fs.Length;
                fs.Seek(0, SeekOrigin.Begin);
                using (var sha = new SHA1CryptoServiceProvider())
                {
                    sentryHash = sha.ComputeHash(fs);
                }
            }

            /*Inform steam servers that we're accepting this sentry file*/
            mSteam.user.SendMachineAuthResponse(new SteamUser.MachineAuthDetails
            {
                /*Set the information recieved*/
                JobID = callback.JobID,
                FileName = callback.FileName,

                BytesWritten = callback.BytesToWrite,
                FileSize = fileSize,
                Offset = callback.Offset,

                Result = EResult.OK,
                LastError = 0,

                OneTimePassword = callback.OneTimePassword,
                SentryFileHash = sentryHash,
            });
        }


        /// <summary>
        /// OnLoggedOn Callback
        /// Fires when User logs in successfully
        /// </summary>
        /// <param name="callback"></param>
        private void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            if (callback.Result == EResult.AccountLogonDenied)
            {
                /*SteamGuard required*/
                Print("Enter the SteamGuard code from your email:");
                mSteam.loginDetails.AuthCode = Console.ReadLine();
                return;
            }
            else if(callback.Result == EResult.AccountLoginDeniedNeedTwoFactor)
            {
                /*Account requires two-way authentication*/
                Print("Enter your two-way authentication code:");
                mSteam.loginDetails.TwoFactorCode = Console.ReadLine();
                return;
            }
            
            string userInfo = string.Format("{0},{1}", mInfo.Username, mInfo.Password);
            if (callback.Result != EResult.OK)
            {
                if (callback.Result == EResult.InvalidPassword)
                {
                    /*Incorrect password*/
                    /*Delete old user info*/
                    Properties.Settings.Default.UserInfo.Remove(userInfo);
                    Properties.Settings.Default.Save();
                    
                    Print("{0} - Invalid password! Try again:", callback.Result);
                    mSteam.loginDetails.Password = Password.ReadPassword();
                    return;
                }
                else if (callback.Result == EResult.TwoFactorCodeMismatch)
                {
                    /*Incorrect two-factor*/
                    Print("{0} - Invalid two factor code! Try again:", callback.Result);
                    mSteam.loginDetails.TwoFactorCode = Console.ReadLine();
                    return;
                }
                else if (callback.Result == EResult.AccountLogonDenied)
                {
                    /*Incorrect email code*/
                    Print("{0} - Invalid email auth code! Try again:", callback.Result);
                    mSteam.loginDetails.AuthCode = Console.ReadLine();
                    return;
                }

                Print("Uncaught EResult error when logging in: {0}", callback.Result);
                return;
            }

            /*Logged in successfully*/
            Print("Successfully logged in!\n");
            mSteam.nounce = callback.WebAPIUserNonce;
            mBotState = BotState.LoggedIn;

            /*Since login was successfull we can save the password here*/
            /*Yep, it's done in plaintext is resources. Deal with it.*/
            if (!Properties.Settings.Default.UserInfo.Contains(userInfo))
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save the password?", "Save info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Properties.Settings.Default.UserInfo.Add(userInfo);
                    Properties.Settings.Default.Save();
                }
            }

            /*Gets a random extra time for the timer*/
            var random = new Random();
            int extraTime = random.Next(20, 60);

            /*Set the timer if it's not already enabled*/
            if (!mGameTimer.Enabled && mSettings.RestartGamesEveryThreeHours)
            {
                mGameTimer.Interval = TimeSpan.FromMinutes(180 + extraTime).TotalMilliseconds;
                mGameTimer.Elapsed += new ElapsedEventHandler(PreformStopStart);
                mGameTimer.Start();
            }

            /*Set games playing*/
            SetGamesPlaying(true);
        }


        /// <summary>
        /// Retreive the login key for account
        /// </summary>
        /// <param name="callback"></param>
        private void OnLoginKey(SteamUser.LoginKeyCallback callback)
        {
            mSteam.loginDetails.LoginKey = callback.LoginKey;
        }


        /// <summary>
        /// This will simulate stopping playing games and restarting it after a random period
        /// This is called from a timer
        /// </summary>
        private void PreformStopStart(object sender, ElapsedEventArgs e)
        {
            /*Stop games*/
            mGameTimer.Stop();
            SetGamesPlaying(false);
            Print("Stopping games for 5 minutes.");
            Thread.Sleep(TimeSpan.FromMinutes(5));

            /*Start games*/
            Print("Starting games again.");
            SetGamesPlaying(true);
            mGameTimer.Start();
        }


        /// <summary>
        /// Set the game currently playing for cooler looks lel
        /// </summary>
        /// <param name="state">True to start games, False to stop</param>
        private void SetGamesPlaying(bool state)
        {
            /*Local list*/
            var gameList = new List<int>();

            /*To start boosting we'll give the local list the values from settings*/
            /*To stop boosting we'll simply pass an empty list*/
            if (state)
                gameList = mSteam.games;

            /*Set up requested games*/
            var gamesPlaying = new ClientMsgProtobuf<CMsgClientGamesPlayed>(EMsg.ClientGamesPlayed);
            foreach(int game in gameList)
            {
                gamesPlaying.Body.games_played.Add(new CMsgClientGamesPlayed.GamePlayed
                {
                    game_id = new GameID(game)
                });
            }

            /*Tell the client that we're playing these games*/
            mSteam.client.Send(gamesPlaying);

            /*If we should go online*/
            if (mInfo.ShowOnlineStatus)
                mSteam.friends.SetPersonaState(EPersonaState.Online);
        }
    }
}
