using System.Collections.Generic;
using SingleBoostr.Core.Objects;

namespace HourBoostr.Settings.Objects
{
    public class Config
    {
        /// <summary>
        /// Class for accounts
        /// </summary>
        public class Settings
        {
            /// <summary>
            /// If we should check for updates when we start the program
            /// </summary>
            public bool CheckForUpdates { get; set; } = true;


            /// <summary>
            /// If we should hide application to tray
            /// </summary>
            public bool HideToTray { get; set; } = true;


            /// <summary>
            /// List of accounts
            /// </summary>
            public List<AccountSettings> Accounts { get; set; } = new List<AccountSettings>();
        }

 
        public class Game
        {
            public string name { get; set; }
            public int id { get; set; }
        }
    }
}
