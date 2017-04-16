using System;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using System.ComponentModel;
using System.IO;
using SteamKit2;
using SteamKit2.Discovery;
using SteamKit2.Internal;

namespace HourBoostr
{
    class Session
    {
        /// <summary>
        /// List of active bot accounts
        /// </summary>
        public List<Bot> mActiveBotList { get; set; } = new List<Bot>();


        /// <summary>
        /// Session background worker
        /// </summary>
        public BackgroundWorker mBwg = new BackgroundWorker();


        /// <summary>
        /// Application settings
        /// </summary>
        public Config.Settings mSettings;


        /// <summary>
        /// Thread for updating title status
        /// </summary>
        private Thread mThreadStatus;


        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="settings"></param>
        public Session(Config.Settings settings)
        {
            mSettings = settings;

            if (settings.CheckForUpdates && Update.IsUpdateAvailable())
                Console.WriteLine("There's an update available. Check out https://github.com/Ezzpify/HourBoostr/releases/latest");

            mBwg.DoWork += MBwg_DoWork;
            mBwg.RunWorkerAsync();
        }


        /// <summary>
        /// Backgroundworker to start all bots
        /// </summary>
        private void MBwg_DoWork(object sender, DoWorkEventArgs e)
        {
            /*Go through account and log them into steam*/
            //SteamDirectory.Initialize().ConfigureAwait(true);
            InitializeCMs(Program.mGlobalDB.CellID, Program.mGlobalDB.ServerListProvider);
            foreach (var account in mSettings.Accounts)
            {
                if (account.IgnoreAccount)
                {
                    Console.WriteLine($"{account.Details.Username} has been ignored.");
                    continue;
                }

                var bot = new Bot(account);
                mActiveBotList.Add(bot);

                /*We'll wait for the bot to log in before starting on the next bot
                We won't wait for it to authenticate, should that be enabled*/
                while (bot.mBotState == Bot.BotState.LoggedOut)
                    Thread.Sleep(100);
            }

            /*Accounts statistics and some fucking baller ascii*/
            Console.Clear();
            Console.WriteLine($"\n   _____             _               _       ");
            Console.WriteLine($"  |  |  |___ _ _ ___| |_ ___ ___ ___| |_ ___ ");
            Console.WriteLine($"  |     | . | | |  _| . | . | . |_ -|  _|  _|");
            Console.WriteLine($"  |__|__|___|___|_| |___|___|___|___|_| |_|  \n");
            Console.WriteLine($"  Source: https://github.com/Ezzpify/HourBoostr");
            Console.WriteLine($"  Build date: {File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location)}");
            Console.WriteLine($"  Version: {Utils.GetVersion()}\n");
            Console.WriteLine($"  ----------------------------------------");
            Console.WriteLine($"\n  Loaded {mActiveBotList.Count} accounts\n\n  Account list:");
            mActiveBotList.ForEach(o => Console.WriteLine("      {0} | {1} Games", o.mAccountSettings.Details.Username, o.mSteam.games.Count));
            Console.WriteLine($"\n\n  Log:\n  ----------------------------------------\n");

            /*Start status thread*/
            mThreadStatus = new Thread(ThreadStatus);
            mThreadStatus.Start();
        }


        /// <summary>
        /// Borrowed this part from
        /// https://github.com/JustArchi/ArchiSteamFarm
        /// </summary>
        /// <param name="cellId">steam cellid</param>
        /// <param name="serverList">list of cm servers</param>
        private void InitializeCMs(uint cellId, IServerListProvider serverList)
        {
            CMClient.Servers.CellID = cellId;
            CMClient.Servers.ServerListProvider = serverList;
            Console.WriteLine("Initializing SteamDirectory ...");

            try
            {
                SteamDirectory.Initialize(cellId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error configuring CM. Connecting might take longer than usual. {ex.Message}");
            }
        }


        /// <summary>
        /// Returns the DateTime of when the application was built
        /// </summary>
        /// <returns>DateTime</returns>
        private DateTime GetBuildDate()
        {
            var version = Assembly.GetEntryAssembly().GetName().Version;
            return new DateTime(2000, 1, 1).Add(new TimeSpan(
                TimeSpan.TicksPerDay * version.Build +
                TimeSpan.TicksPerSecond * 2 * version.Revision));
        }


        /// <summary>
        /// Status for how long the bot has been running
        /// </summary>
        private void ThreadStatus()
        {
            var initializedTime = DateTime.Now;

            while (true)
            {
                /*Get the current time then subtract the time when all bots were done initializing*/
                /*This will give us an idea of how long the bot has been running*/
                TimeSpan timeSpan = DateTime.Now - initializedTime;
                string timeSpentOnline = string.Format("{0} Hours {1} Minutes {2} Seconds",
                    (timeSpan.Days * 24) + timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

                Console.Title = $"{EndPoint.CONSOLE_TITLE} | Online for: {timeSpentOnline}";
                Thread.Sleep(500);
            }
        }
    }
}