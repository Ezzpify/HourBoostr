using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using System.Reflection;

namespace HourBoostr
{
    class Session
    {
        /// <summary>
        /// List of active bot accounts
        /// </summary>
        public List<Bot> mActiveBotList { get; set; } = new List<Bot>();


        /// <summary>
        /// DateTime representing when all
        /// accounts were initialized
        /// </summary>
        private DateTime mInitializedTime;


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
            StartBotAccounts();
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
        /// Gets the updated account settings from all active bots
        /// </summary>
        /// <returns>Config.Settings</returns>
        public Config.Settings GetUpdatedSettings()
        {
            var settings = mSettings;
            settings.Account = new List<Config.AccountSettings>();
            mActiveBotList.ForEach(o => settings.Account.Add(o.mAccountSettings));

            return settings;
        }


        /// <summary>
        /// Main function
        /// This is run on a seperate thread
        /// This will initialize the bots
        /// </summary>
        private void StartBotAccounts()
        {
            /*Go through account and log them into steam*/
            foreach (var account in mSettings.Account)
            {
                var bot = new Bot(account);
                mActiveBotList.Add(bot);

                while (bot.mBotState == Bot.BotState.LoggedOut)
                    Thread.Sleep(100);
            }

            /*Accounts statistics and some fucking baller ascii*/
            Console.Clear();
            Console.WriteLine($"\n   _____             _               _       ");
            Console.WriteLine($"  |  |  |___ _ _ ___| |_ ___ ___ ___| |_ ___ ");
            Console.WriteLine($"  |     | . | | |  _| . | . | . |_ -|  _|  _|");
            Console.WriteLine($"  |__|__|___|___|_| |___|___|___|___|_| |_|  \n");
            Console.WriteLine($"  Source: https://github.com/Ezzpify/");
            Console.WriteLine($"  Build date: {GetBuildDate().ToString()}\n");
            Console.WriteLine($"  ----------------------------------------");
            Console.WriteLine($"\n  Loaded {mActiveBotList.Count} accounts\n\n  Account list:");
            mActiveBotList.ForEach(o => Console.WriteLine("      {0} | {1} Games", o.mAccountSettings.Username, o.mSteam.games.Count));
            Console.WriteLine($"\n\n  Log:\n  ----------------------------------------\n");
            mInitializedTime = DateTime.Now;

            /*Start status thread*/
            mThreadStatus = new Thread(ThreadStatus);
            mThreadStatus.Start();
        }


        /// <summary>
        /// Status for how long the bot has been running
        /// </summary>
        private void ThreadStatus()
        {
            while (true)
            {
                /*Get the current time then subtract the time when all bots were done initializing*/
                /*This will give us an idea of how long the bot has been running*/
                TimeSpan timeSpan = DateTime.Now - mInitializedTime;
                string timeSpentOnline = string.Format("{0} Hours {1} Minutes {2} Seconds", 
                    (timeSpan.Days * 24) + timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

                Console.Title = string.Format("HourBoostr | Online for: {0}", timeSpentOnline);
                Thread.Sleep(1000);
            }
        }
    }
}
