using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HourBoostr
{
    class Session
    {
        /// <summary>
        /// Application settings
        /// </summary>
        private Config.Settings mSettings;


        /// <summary>
        /// DateTime representing when all accounts were initialized
        /// </summary>
        private DateTime mInitializedTime;


        /// <summary>
        /// List of active bot accounts
        /// </summary>
        public List<Bot> mActiveBots { get; set; } = new List<Bot>();


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
            DoWork();
        }


        /// <summary>
        /// Gets the user information from settings
        /// </summary>
        /// <param name="username">Username of user to query</param>
        /// <returns>Returns empty string if none found</returns>
        private string GetUserInformation(string username)
        {
            var strList = Properties.Settings.Default.UserInfo.Cast<string>().ToList();
            if (strList.Count > 0)
            {
                return strList.FirstOrDefault(o => o.ToLower().Contains(username.ToLower()));
            }

            return string.Empty;
        }


        /// <summary>
        /// Main function
        /// This is run on a seperate thread
        /// This will initialize the bots
        /// </summary>
        private void DoWork()
        {
            foreach (var account in mSettings.Account)
            {
                /*Get the stored password*/
                /*If no password is stored it can be set from BotClass.cs*/
                /*I'm aware this is stored in plaintext, but literally who cares with this application*/
                /*If you are no comfortable with it being stores as plaintext in settings, don't save the password*/
                string userInfo = GetUserInformation(account.Username);
                if (!string.IsNullOrEmpty(userInfo))
                {
                    var spl = userInfo.Split(',');
                    if (spl.Length == 2)
                    {
                        account.Password = spl[1];
                    }
                }

                /*Start the bot*/
                Bot bot = new Bot(account, mSettings);
                mActiveBots.Add(bot);
                while (bot.mBotState != Bot.BotState.LoggedIn) { Thread.Sleep(300); }
            }

            /*Accounts statistics and some fucking baller ascii*/
            Console.Clear();
            Console.WriteLine("\n  _____             _               _       ");
            Console.WriteLine(" |  |  |___ _ _ ___| |_ ___ ___ ___| |_ ___ ");
            Console.WriteLine(" |     | . | | |  _| . | . | . |_ -|  _|  _|");
            Console.WriteLine(" |__|__|___|___|_| |___|___|___|___|_| |_|  \n");
            Console.WriteLine("  https://github.com/Ezzpify/\n");
            Console.WriteLine("  ----------------------------------------");
            Console.WriteLine("\n  Loaded {0} accounts\n\n  Accounts:", mActiveBots.Count);
            mActiveBots.ForEach(o => Console.WriteLine("      {0} | {1} Games", o.mInfo.Username, o.mSteam.games.Count));
            mInitializedTime = DateTime.Now;

            /*Start status thread*/
            mThreadStatus = new Thread(ThreadStatus);
            mThreadStatus.Start();
        }
        

        /// <summary>
        /// Gets the time the bot has been online as finished string
        /// </summary>
        /// <returns>Returns string</returns>
        private string GetOnlineHours()
        {
            TimeSpan timeSpan = DateTime.Now - mInitializedTime;
            return string.Format("{0} Hours {1} Minutes {2} Seconds", (timeSpan.Days * 24) + timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
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
                Console.Title = string.Format("HourBoostr | Online for: {0}", GetOnlineHours());
                Thread.Sleep(1000);
            }
        }
    }
}
