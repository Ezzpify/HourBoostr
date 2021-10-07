﻿using SingleBoostr.Core.Misc;
using System.Collections.Generic;

namespace HourBoostr.Objects
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
            private bool PasswordSet => !string.IsNullOrEmpty(Password) && !string.IsNullOrWhiteSpace(Password);
            private string PasswordSalt = StringCipher.EncryptSHA1(SingleBoostr.Core.Misc.Utils.GetMachineGuid());
            public void Encrypt() => Password = PasswordSet ? StringCipher.Encrypt(Password, PasswordSalt) : Password;
            public void Decrypt() => Password = PasswordSet ? StringCipher.Decrypt(Password, PasswordSalt) : Password;



            /// <summary>
            /// Login key for steam account
            /// Saving this means we don't have to enter code twice
            /// </summary>
            public string LoginKey { get; set; } = "";
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
            /// If we should authenticate to community
            /// </summary>
            public bool ConnectToSteamCommunity { get; set; } = true;


            /// <summary>
            /// If we should restart games every 3 hours
            /// This is to prevent steam to no longer get hours if we idle for a long period of time
            /// </summary>
            public bool RestartGamesEveryThreeHours { get; set; } = true;


            /// <summary>
            /// Automatically joins the Steam Group for HourBoostr
            /// This is done for statistics, so feel free to disable it if you don't want it
            /// </summary>
            public bool JoinSteamGroup { get; set; } = true;


            /// <summary>
            /// If we should ignore running this account
            /// Useful if user doesn't want to boost a particular account right now but
            /// don't want to delete it from settings file because that's annoying as fuck
            /// </summary>
            public bool IgnoreAccount { get; set; } = false;


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