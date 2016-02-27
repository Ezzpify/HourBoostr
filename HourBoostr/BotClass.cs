using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using SteamKit2;
using System.Timers;
using SteamKit2.Internal;
using System.Security.Cryptography;

namespace HourBoostr
{
    class BotClass
    {
        /// <summary>
        /// Class for holding Steam information
        /// </summary>
        public class Steam
        {
            /// <summary>
            /// Specifies the location to the sentry path for this account
            /// </summary>
            public string sentryPath { get; set; }


            /// <summary>
            /// Web api user nounce
            /// </summary>
            public string nounce { get; set; }

            
            /// <summary>
            /// List of games that we will be playing
            /// </summary>
            public List<int> games { get; set; }


            /// <summary>
            /// Steam client
            /// </summary>
            public SteamClient client { get; set; }


            /// <summary>
            /// Steam user
            /// </summary>
            public SteamUser user { get; set; }


            /// <summary>
            /// Steam friends
            /// </summary>
            public SteamFriends friends { get; set; }


            /// <summary>
            /// Login details for this account
            /// </summary>
            public SteamUser.LogOnDetails loginDetails { get; set; }


            /// <summary>
            /// Callback manager
            /// </summary>
            public CallbackManager callbackManager { get; set; }
        }


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
        public bool mIsRunning { get; set; } = true;


        /// <summary>
        /// State of bot status
        /// </summary>
        public BotState mBotState { get; private set; } = BotState.LoggedOut;


        /// <summary>
        /// The steam session of the bot
        /// We can instance this on load
        /// </summary>
        public Steam mSteam { get; set; } = new Steam();


        /// <summary>
        /// Thread variables
        /// </summary>
        private Thread mThreadCallback;


        /// <summary>
        /// Information for this account
        /// </summary>
        public Config.AccountInfo mInfo { get; private set; }


        /// <summary>
        /// Timer to simulate stopping and restarting a game
        /// </summary>
        private System.Timers.Timer mGameTimer;


        /// <summary>
        /// Main initializer for each account
        /// </summary>
        /// <param name="info">Account info</param>
        public BotClass(Config.AccountInfo info)
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
                Password = info.Password
            };
            mInfo = info;
            mSteam.games = info.Games;
            mSteam.sentryPath = Path.Combine(Application.StartupPath, string.Format("Sentryfiles\\{0}.sentry", info.Username));

            /*Assign clients*/
            mSteam.client = new SteamClient();
            mSteam.callbackManager = new CallbackManager(mSteam.client);
            mSteam.user = mSteam.client.GetHandler<SteamUser>();
            mSteam.friends = mSteam.client.GetHandler<SteamFriends>();

            /*Assign Callbacks*/
            new Callback<SteamClient.ConnectedCallback>(OnConnected, mSteam.callbackManager);
            new Callback<SteamClient.DisconnectedCallback>(OnDisconnected, mSteam.callbackManager);
            new Callback<SteamUser.LoggedOnCallback>(OnLoggedOn, mSteam.callbackManager);
            new Callback<SteamUser.UpdateMachineAuthCallback>(OnMachineAuth, mSteam.callbackManager);

            /*Connect to Steam*/
            Print("Connecting to steam ...", info.Username);
            mSteam.client.Connect();

            /*Start Callback thread*/
            mThreadCallback = new Thread(RunCallback);
            mThreadCallback.Start();
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
        /// Continues the callbacks
        /// Terminates if Bot stops or Thread _callbackThread is killed
        /// </summary>
        private void RunCallback()
        {
            while(mIsRunning)
            {
                mSteam.callbackManager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            }
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
                mSteam.client.Connect();
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
            /*Fetch if SteamGuard is required*/
            if (callback.Result == EResult.AccountLogonDenied)
            {
                /*SteamGuard required*/
                Print("Enter the SteamGuard code from your email:");
                mSteam.loginDetails.AuthCode = Console.ReadLine();
                return;
            }

            /*If two-way authentication*/
            if(callback.Result == EResult.AccountLogonDeniedNeedTwoFactorCode)
            {
                /*Account requires two-way authentication*/
                Print("Enter your two-way authentication code:");
                mSteam.loginDetails.TwoFactorCode = Console.ReadLine();
                return;
            }

            /*Something terrible has happened*/
            string userInfo = string.Format("{0},{1}", mInfo.Username, mInfo.Password);
            if (callback.Result != EResult.OK)
            {
                /*Incorrect password*/
                if (callback.Result == EResult.InvalidPassword)
                {
                    /*Delete old user info*/
                    Properties.Settings.Default.UserInfo.Add(userInfo);
                    Properties.Settings.Default.Save();
                    
                    Print("{0} - Invalid password! Try again:", callback.Result);
                    mSteam.loginDetails.Password = Password.ReadPassword();
                }

                /*Incorrect two-factor*/
                if (callback.Result == EResult.TwoFactorCodeMismatch)
                {
                    Print("{0} - Invalid two factor code! Try again:", callback.Result);
                    mSteam.loginDetails.TwoFactorCode = Console.ReadLine();
                }

                /*Incorrect email code*/
                if (callback.Result == EResult.AccountLogonDenied)
                {
                    Print("{0} - Invalid email auth code! Try again:", callback.Result);
                    mSteam.loginDetails.AuthCode = Console.ReadLine();
                }

                /*Disconnect and retry*/
                mSteam.client.Disconnect();
                mBotState = BotState.LoggedOut;
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

            /*Set the timer*/
            mGameTimer = new System.Timers.Timer();
            mGameTimer.Interval = TimeSpan.FromMinutes(180 + extraTime).TotalMilliseconds;
            mGameTimer.Elapsed += new ElapsedEventHandler(PreformStopStart);
            mGameTimer.Start();

            /*Set games playing*/
            SetGamesPlaying(true);
        }


        /// <summary>
        /// This will simulate stopping playing games and restarting it after a random period
        /// This is called from a timer
        /// </summary>
        private void PreformStopStart(object sender, ElapsedEventArgs e)
        {
            mGameTimer.Stop();
            SetGamesPlaying(false);
            Print("Stopping games for 5 minutes.");
            Thread.Sleep(TimeSpan.FromMinutes(5));
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
                    game_id = new GameID(game),
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
