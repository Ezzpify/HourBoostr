using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using SteamKit2;
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

                /*Save password prompt*/
                DialogResult dialogResult = MessageBox.Show("Do you want to save the password?", "Save info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string userInfo = string.Format("{0},{1}", mSteam.loginDetails.Username, mSteam.loginDetails.Password);
                    Properties.Settings.Default.UserInfo.Add(userInfo);
                    Properties.Settings.Default.Save();
                }
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
                Print(string.Format("Error: {0}", callback.Result));
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
            if(callback.Result != EResult.OK)
            {
                /*Incorrect password*/
                if(callback.Result == EResult.InvalidPassword)
                {
                    /*Get user to enter a new password*/
                    Print(string.Format("{0} - Invalid password! Try again:", callback.Result));

                    /*Delete old user info*/
                    Properties.Settings.Default.UserInfo.Remove(string.Format("{0},{1}", mSteam.loginDetails.Username, mSteam.loginDetails.Password));
                    Properties.Settings.Default.Save();

                    /*Read new password from input*/
                    mSteam.loginDetails.Password = Password.ReadPassword();

                    /*Disconnect and retry*/
                    mSteam.client.Disconnect();
                    return;
                }

                /*Something else happened that I didn't account for*/
                Print(string.Format("{0} - Something failed. Redo process please.", callback.Result));
                mBotState = BotState.LoggedOut;
                return;
            }

            /*Logged in successfully*/
            Print("Successfully logged in!\n");
            mSteam.nounce = callback.WebAPIUserNonce;
            mBotState = BotState.LoggedIn;

            /*Set games playing*/
            SetGamesPlaying();
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
        /// Set the game currently playing for cooler looks lel
        /// </summary>
        /// <param name="id"></param>
        private void SetGamesPlaying()
        {
            /*Set up requested games*/
            var gamesPlaying = new SteamKit2.ClientMsgProtobuf<CMsgClientGamesPlayed>(EMsg.ClientGamesPlayed);
            foreach(int Game in mSteam.games)
            {
                gamesPlaying.Body.games_played.Add(new CMsgClientGamesPlayed.GamePlayed
                {
                    game_id = new GameID(Game),
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
