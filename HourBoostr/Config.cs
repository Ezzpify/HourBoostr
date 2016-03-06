using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace HourBoostr
{
    public class Config
    {
        /// <summary>
        /// Class for accounts
        /// </summary>
        public class Settings
        {
            /// <summary>
            /// If we should restart games every 3 hours
            /// This is to prevent steam to no longer get hours if we idle for a long period of time
            /// </summary>
            public bool RestartGamesEveryThreeHours { get; set; } = true;


            /// <summary>
            /// If we should automatically hide the program to tray bar
            /// I fucking hate this so I want to disable it
            /// </summary>
            public bool HideToTrayAutomatically { get; set; } = true;


            /// <summary>
            /// List of accounts
            /// </summary>
            public List<AccountInfo> Account { get; set; } = new List<AccountInfo>();
        }


        /// <summary>
        /// Class for account info
        /// </summary>
        public class AccountInfo
        {
            /// <summary>
            /// Username of steam *account
            /// </summary>
            public string Username { get; set; }


            /// <summary>
            /// Password of the steam account
            /// This will be set manually by user from console
            /// This will not be printed or read from json file
            /// </summary>
            [JsonIgnore]
            public string Password { get; set; }


            /// <summary>
            /// If we should set steam status to online
            /// </summary>
            public bool ShowOnlineStatus { get; set; }


            /// <summary>
            /// List of games we should set as playing
            /// </summary>
            public List<int> Games { get; set; } = new List<int>();


            /// <summary>
            /// Sets pre-defined temp values to the class variables
            /// Good for showing people how the Json file should look like
            /// </summary>
            public void SetTemporaryValues()
            {
                Username = "UsernameHere";
                Games.Add(730);
                Games.Add(10);
            }
        }
    }
}
