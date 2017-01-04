using System.Collections.Generic;
using SteamKit2;

namespace HourBoostr
{
    class Steam
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
        /// Steam web for community access
        /// </summary>
        public SteamWeb web { get; set; }


        /// <summary>
        /// UniqueID fetched when getting loginKey
        /// </summary>
        public string uniqueId { get; set; }


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


        /// <summary>
        /// Extra cb handler for fun stuff
        /// (Thanks Archi)
        /// </summary>
        public ExtraHandler extraHandler { get; set; }
    }
}