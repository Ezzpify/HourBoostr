using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public class Config
    {
        /// <summary>
        /// Class for accounts
        /// </summary>
        public class Settings
        {
            /// <summary>
            /// If we should automatically hide the program to tray bar
            /// I fucking hate this so I want to disable it
            /// </summary>
            public bool HideToTrayAutomatically { get; set; } = true;


            /// <summary>
            /// List of accounts
            /// </summary>
            public List<AccountSettings> Accounts { get; set; } = new List<AccountSettings>();
        }


        /// <summary>
        /// Holds account details
        /// </summary>
        public class Details
        {
            /// <summary>
            /// Username of steam account
            /// </summary>
            public string Username { get; set; } = "";


            /// <summary>
            /// Password of the steam account
            /// This will be set manually by user from console
            /// This will not be printed or read from json file
            /// </summary>
            public string Password { get; set; } = "";


            /// <summary>
            /// Login key for steam account
            /// Saving this means we don't have to enter code twice
            /// </summary>
            public string LoginKey { get; set; } = "";
        }


        /// <summary>
        /// Class for game
        /// </summary>
        public class Game
        {
            /// <summary>
            /// Steam game name
            /// </summary>
            public string name { get; set; }


            /// <summary>
            /// Steam game (app) id
            /// </summary>
            public int id { get; set; }
        }


        /// <summary>
        /// Class for account settings
        /// </summary>
        public class AccountSettings
        {
            /// <summary>
            /// Holds all the account login information
            /// </summary>
            public Details Details { get; set; } = new Details();


            /// <summary>
            /// If we should set steam status to online
            /// </summary>
            public bool ShowOnlineStatus { get; set; } = true;


            /// <summary>
            /// If we should relog the account every 4 hours
            /// This will only be called if LoginKey is set
            /// </summary>
            public bool RelogEveryFourHours { get; set; }


            /// <summary>
            /// If we should authenticate to community
            /// </summary>
            public bool ConnectToSteamCommunity { get; set; } = true;


            /// <summary>
            /// If we should restart games every 3 hours
            /// This is to prevent steam to no longer get hours if we idle for a long period of time
            /// </summary>
            public bool RestartGamesEveryThreeHours { get; set; }


            /// <summary>
            /// What the bot should reply if someone sends it a message
            /// </summary>
            public string ChatResponse { get; set; } = "";


            /// <summary>
            /// List of games we should set as playing
            /// </summary>
            public List<int> Games { get; set; } = new List<int>();
        }
    }
}
