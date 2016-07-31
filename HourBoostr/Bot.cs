﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Timers;
using System.Linq;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Net;
using SteamKit2.Internal;
using SteamKit2;

namespace HourBoostr
{
    class Bot
    {
        class ChatMessageData
        {
            /// <summary>
            /// Steam account id
            /// </summary>
            public uint AccountId { get; set; }


            /// <summary>
            /// DataTime when we received the message
            /// </summary>
            public DateTime DateReceived { get; set; }
        }


        /// <summary>
        /// List of users we've already replied to in chat
        /// </summary>
        private List<ChatMessageData> mAlreadyRepliedChatMsg = new List<ChatMessageData>();


        /// <summary>
        /// Thread for running forced community connection
        /// </summary>
        private System.Timers.Timer mCommunityTimer = new System.Timers.Timer();


        /// <summary>
        /// Timer to simulate stopping and restarting a game
        /// </summary>
        private System.Timers.Timer mGameTimer = new System.Timers.Timer();


        /// <summary>
        /// Bot thread
        /// </summary>
        private BackgroundWorker mBotThread = new BackgroundWorker();


        /// <summary>
        /// The steam session of the bot
        /// We can instance this on load
        /// </summary>
        public Steam mSteam { get; set; } = new Steam();


        /// <summary>
        /// Information for this account
        /// </summary>
        public Config.AccountSettings mAccountSettings;


        /// <summary>
        /// Represents how many times we've disconnected
        /// This will be reset when we hit n disconnects and a pause is forced
        /// </summary>
        private int mDisconnectedCounter;


        /// <summary>
        /// If we have connected once successfully this will be true
        /// Good to know if we disconnect
        /// </summary>
        public bool mHasConnectedOnce;


        /// <summary>
        /// Bot logs
        /// </summary>
        private Log mLog, mLogChat;


        /// <summary>
        /// State of bot status
        /// </summary>
        public BotState mBotState;


        /// <summary>
        /// Represents if the bot is in running state
        /// </summary>
        public bool mIsRunning;


        /// <summary>
        /// Enum for bot state
        /// </summary>
        public enum BotState
        {
            LoggedOut, LoggedIn, LoggedInWeb
        }


        /// <summary>
        /// Main initializer for each account
        /// </summary>
        /// <param name="info">Account info</param>
        public Bot(Config.AccountSettings info)
        {
            /*If a password isn't set we'll ask for user input*/
            if (string.IsNullOrWhiteSpace(info.Password) && string.IsNullOrWhiteSpace(info.LoginKey))
            {
                Console.WriteLine("Enter password for account '{0}'", info.Username);
                info.Password = Password.ReadPassword('*');
            }

            /*Assign bot info*/
            mSteam.loginDetails = new SteamUser.LogOnDetails()
            {
                Username = info.Username,
                Password = info.Password,
                LoginKey = info.LoginKey,
                ShouldRememberPassword = true,
            };
            mAccountSettings = info;
            mSteam.games = info.Games;
            mSteam.sentryPath = Path.Combine(Application.StartupPath, string.Format("Sentryfiles\\{0}.sentry", info.Username));

            /*Set up steamweb*/
            mSteam.web = new SteamWeb();
            ServicePointManager.ServerCertificateValidationCallback += mSteam.web.ValidateRemoteCertificate;

            /*Create logs*/
            mLog = new Log(info.Username, Path.Combine(EndPoint.LOG_FOLDER_PATH, $"{info.Username}.txt"), 1);
            mLogChat = new Log($"{info.Username} Chat", Path.Combine(EndPoint.LOG_FOLDER_PATH, $"{info.Username} steam chat.txt"), 1);

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
            mSteam.callbackManager.Subscribe<SteamUser.WebAPIUserNonceCallback>(OnWebAPIUserNonce);
            mSteam.callbackManager.Subscribe<SteamFriends.FriendMsgCallback>(OnFriendMsgCallback);

            /*Start Callback thread*/
            mBotThread.DoWork += BackgroundWorkerOnDoWork;
            mBotThread.RunWorkerCompleted += BackgroundWorkerOnRunWorkerCompleted;
            mBotThread.RunWorkerAsync();
            Connect();
        }


        /// <summary>
        /// Connect to Steam
        /// </summary>
        private void Connect()
        {
            mIsRunning = true;
            mLog.Write(Log.LogLevel.Info, $"Connecting to Steam ...");
            SteamDirectory.Initialize().Wait();
            mSteam.client.Connect();
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
                catch (Exception ex)
                {
                    mLog.Write(Log.LogLevel.Warn, $"Exception occured for callbackManager: {ex}");
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
                mLog.Write(Log.LogLevel.Error, $"Unhandled exception occured in callbackManager background worker: {ex.Message}");
            }
            
            mLog.Write(Log.LogLevel.Warn, $"Bot has stopped running!");
            mIsRunning = false;
        }


        /// <summary>
        /// OnConnected Callback
        /// Fires when Client connects to Steam
        /// </summary>
        /// <param name="callback">SteamClient.ConnectedCallback</param>
        private void OnConnected(SteamClient.ConnectedCallback callback)
        {
            if(callback.Result != EResult.OK)
            {
                mLog.Write(Log.LogLevel.Warn, $"OnConnected error: {callback.Result}");
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
            mLog.Write(Log.LogLevel.Info, $"Connected! Logging in ...");
            mSteam.loginDetails.SentryFileHash = sentryHash;
            mSteam.user.LogOn(mSteam.loginDetails);
        }


        /// <summary>
        /// OnDisconnected Callback
        /// Fires when Client disconnects from Steam
        /// Will also fire when setting up an account to re-auth
        /// </summary>
        /// <param name="callback">SteamClient.DisconnectedCallback</param>
        private void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            /*Only want to count a disconnect if the bot was disconnected*/
            /*while it was fully logged in*/
            if (mBotState == BotState.LoggedIn)
                mDisconnectedCounter++;

            mBotState = BotState.LoggedOut;
            if (mIsRunning)
            {
                if (mDisconnectedCounter <= 3)
                {
                    mLog.Write(Log.LogLevel.Info, $"Reconnecting in 3s ...");
                    Thread.Sleep(3000);
                }
                else
                {
                    mLog.Write(Log.LogLevel.Warn, $"Too many disconnects occured in a short period of time. Sleeping for 15 minutes.");
                    Thread.Sleep(TimeSpan.FromMinutes(15));
                    mDisconnectedCounter = 0;
                }

                Connect();
            }
        }


        /// <summary>
        /// OnMachineAuth Callback
        /// Fires when User is authenticating the Steam account
        /// </summary>
        /// <param name="callback">SteamUser.UpdateMachineAuthCallback</param>
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
        /// <param name="callback">SteamUser.LoggedOnCallback</param>
        private void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            switch (callback.Result)
            {
                case EResult.AccountLogonDenied:
                    mLog.Write(Log.LogLevel.Text, $"Enter the SteamGuard code from your email:");
                    mSteam.loginDetails.AuthCode = Console.ReadLine();
                    return;

                case EResult.AccountLoginDeniedNeedTwoFactor:
                    mLog.Write(Log.LogLevel.Text, $"Enter your two-way authentication code:");
                    mSteam.loginDetails.TwoFactorCode = Console.ReadLine();
                    return;

                case EResult.InvalidPassword:
                    mLog.Write(Log.LogLevel.Warn, $"The password was not accepted.");
                    
                    if (!mHasConnectedOnce)
                    {
                        /*Remove LoginKey if we haven't been logged in before*/
                        mLog.Write(Log.LogLevel.Info, $"Removed LoginKey for this account");
                        mSteam.loginDetails.LoginKey = string.Empty;
                        mAccountSettings.LoginKey = string.Empty;
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(mAccountSettings.Password))
                        {
                            /*Re-input password if no password was set in settings*/
                            mLog.Write(Log.LogLevel.Text, $"Re-enter your Steam password:");
                            mSteam.loginDetails.Password = Password.ReadPassword('*');
                        }
                    }
                    return;

                case EResult.TwoFactorCodeMismatch:
                    mLog.Write(Log.LogLevel.Text, $"Invalid two factor code! Try again:");
                    mSteam.loginDetails.TwoFactorCode = Console.ReadLine();
                    return;

                case EResult.ServiceUnavailable:
                    mLog.Write(Log.LogLevel.Warn, $"Service unavailable. We'll force a pause here.");
                    mDisconnectedCounter = 4;
                    return;
            }

            /*We didn't account for what happened*/
            if (callback.Result != EResult.OK)
            {
                mLog.Write(Log.LogLevel.Warn, $"Unhandled EResult response. Please report this issue. --> {callback.Result}");
                return;
            }
            
            /*Logged in successfully*/
            mLog.Write(Log.LogLevel.Success, $"Successfully logged in!");
            mSteam.nounce = callback.WebAPIUserNonce;
            mBotState = BotState.LoggedIn;
            mHasConnectedOnce = true;
            LogOnSuccess();
        }


        /// <summary>
        /// Retreive the login key for account
        /// </summary>
        /// <param name="callback">SteamUser.LoginKeyCallback</param>
        private void OnLoginKey(SteamUser.LoginKeyCallback callback)
        {
            mLog.Write(Log.LogLevel.Info, $"Received LoginKey from Steam");
            mAccountSettings.LoginKey = callback.LoginKey;

            mSteam.uniqueId = callback.UniqueID.ToString();
            mSteam.user.AcceptNewLoginKey(callback);

            if (mAccountSettings.ConnectToSteamCommunity)
                AuthenticateUser();
        }


        /// <summary>
        /// Retrieves the web api nounce and authenticates the user
        /// </summary>
        /// <param name="callback">SteamUser.WebAPIUserNonceCallback</param>
        private void OnWebAPIUserNonce(SteamUser.WebAPIUserNonceCallback callback)
        {
            mLog.Write(Log.LogLevel.Info, $"Received new user nonce from Steam");
            if (callback.Result != EResult.OK)
                return;
            
            mSteam.nounce = callback.Nonce;
            AuthenticateUser();
        }


        /// <summary>
        /// Fires when the bot receives a steam chat message from someone on their friendlist
        /// </summary>
        /// <param name="callback"></param>
        private void OnFriendMsgCallback(SteamFriends.FriendMsgCallback callback)
        {
            if (callback.EntryType != EChatEntryType.ChatMsg)
                return;

            /*Log the message we just received*/
            string friendUserName = mSteam.friends.GetFriendPersonaName(callback.Sender);
            mLogChat.Write(Log.LogLevel.Text, $"Msg from {friendUserName}: {callback.Message}");

            /*Clear blocked users that are older than 20 minutes
            This is to avoid responding every time a user is spamming us in the chat*/
            var blockedUsersDelete = new List<ChatMessageData>();
            foreach (var user in mAlreadyRepliedChatMsg)
            {

                if (DateTime.Now.Subtract(user.DateReceived) > TimeSpan.FromMinutes(20))
                    blockedUsersDelete.Add(user);
            }
            mAlreadyRepliedChatMsg = mAlreadyRepliedChatMsg.Except(blockedUsersDelete).ToList();

            /*Only send a response if one is set in the settings file*/
            if (!string.IsNullOrWhiteSpace(mAccountSettings.ChatResponse))
            {
                /*Set up ChatMessageData object*/
                var msgData = new ChatMessageData()
                {
                    AccountId = callback.Sender.AccountID,
                    DateReceived = DateTime.Now
                };

                /*Check if the list of blocked users contains the sender*/
                if (mAlreadyRepliedChatMsg.Any(o => o.AccountId == msgData.AccountId))
                    return;

                mSteam.friends.SendChatMessage(callback.Sender, EChatEntryType.ChatMsg, mAccountSettings.ChatResponse);
                mLogChat.Write(Log.LogLevel.Info, $"Responded to {friendUserName}");
                mAlreadyRepliedChatMsg.Add(msgData);
            }
        }


        /// <summary>
        /// Attempts to authenticate the user to the steam community
        /// This will only be executed if enabled in settings
        /// </summary>
        private void AuthenticateUser()
        {
            mLog.Write(Log.LogLevel.Info, $"Authenticating user ...");
            UserWebLogOn();
            SetGamesPlaying(true);
        }
        
        
        /// <summary>
        /// Authenticates user to community
        /// </summary>
        private void UserWebLogOn()
        {
            int attempts = 0;
            do
            {
                try
                {
                    /*Try to authenticate to steam community*/
                    if (mSteam.web.Authenticate(mSteam.uniqueId, mSteam.client, mSteam.nounce))
                    {
                        mBotState = BotState.LoggedInWeb;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    mLog.Write(Log.LogLevel.Error, $"Error when attempting to Authenticate user. {ex.Message}");
                }

                if (attempts++ > 3)
                    return;
            }
            while (mBotState != BotState.LoggedInWeb);
            mLog.Write(Log.LogLevel.Success, $"User authenticated!");

            /*If we should go online*/
            if (mAccountSettings.ShowOnlineStatus)
                mSteam.friends.SetPersonaState(EPersonaState.Online);

            /*Start the timer to periodically refresh community connection*/
            if (!mCommunityTimer.Enabled)
            {
                mCommunityTimer.Interval = TimeSpan.FromMinutes(15).TotalMilliseconds;
                mCommunityTimer.Elapsed += new ElapsedEventHandler(ForceCommunity);
                mCommunityTimer.Start();
            }
        }


        /// <summary>
        /// This will periodically 
        /// </summary>
        private void ForceCommunity(object sender, ElapsedEventArgs e)
        {
            if (!mSteam.web.VerifyCookies())
            {
                mLog.Write(Log.LogLevel.Warn, $"Cookies were out of date, requesting new user nonce ...");
                mSteam.user.RequestWebAPIUserNonce();
                mBotState = BotState.LoggedIn;
            }
            else
            {
                /*We'll request a page to keep the community connection active*/
                mSteam.web.Request($"http://www.steamcommunity.com/profiles/{mSteam.user.SteamID}", "GET");
            }
        }


        /// <summary>
        /// Fires when bot is fully logged on
        /// </summary>
        private void LogOnSuccess()
        {
            /*Set the timer if it's not already enabled*/
            int extraTime = new Random().Next(20, 60);
            if (!mGameTimer.Enabled && mAccountSettings.RestartGamesEveryThreeHours)
            {
                mGameTimer.Interval = TimeSpan.FromMinutes(180 + extraTime).TotalMilliseconds;
                mGameTimer.Elapsed += new ElapsedEventHandler(PreformStopStart);
                mGameTimer.Start();
            }

            /*Set games playing*/
            SetGamesPlaying(true);
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
            mLog.Write(Log.LogLevel.Info, $"Stopping games for 5 minutes ...");
            Thread.Sleep(TimeSpan.FromMinutes(5));

            /*Start games*/
            mLog.Write(Log.LogLevel.Info, $"Started games again!");
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
            mLog.Write(Log.LogLevel.Info, $"{gameList.Count} has been set as playing.");
        }
    }
}
