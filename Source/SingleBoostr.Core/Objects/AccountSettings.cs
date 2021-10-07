using System.Collections.Generic;

namespace SingleBoostr.Core.Objects
{
    public class AccountSettings
    {
        /// <summary>
        /// Holds all the account login information
        /// </summary>
        public AccountDetails Details { get; set; } = new AccountDetails();


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
