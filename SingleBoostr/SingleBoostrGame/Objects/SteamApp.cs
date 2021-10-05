using Steam4NET;
using SteamWebAPI2.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Steam.Models.SteamCommunity;
using System.Collections.Generic;

namespace SingleBoostr.Game.Objects
{
    internal class SteamApp
    {   
        private ISteamApps001 _steamApps001;
        private ISteamClient012 _steamClient012;
        private ISteamUser015 _steamUser015;

        /// <summary>
        /// APP ID
        /// </summary>
        internal uint ID { get; private set; } = 0;

        /// <summary>
        /// Check if APP ID is valid
        /// </summary>
        internal bool IDValid => !string.IsNullOrWhiteSpace(ID.ToString()) && ID > 0;

        /// <summary>
        /// Check if APP ID is Set
        /// </summary>
        internal bool IDSet => IDValid && Environment.GetEnvironmentVariable("SteamAppId") == ID.ToString();

        /// <summary>
        /// APP Title
        /// </summary>
        internal string Title { get; private set; } = "Unknown game";

        /// <summary>
        /// APP Image URL
        /// </summary>
        internal string ImageUrl { get; private set; } = "";

        /// <summary>
        /// APP Idle start time
        /// </summary>
        internal DateTime? StartTime { get; set; }

        /// <summary>
        /// APP Idle uptime
        /// </summary>
        internal string UpTime => (DateTime.Now - StartTime).ToString().Split(new[] { '.' })[0];

        /// <summary>
        /// APP Total playtime on record
        /// </summary>
        internal double Playtime { get; private set; } = 0;

        /// <summary>
        /// APP Idling
        /// </summary>
        private bool _running = false;

        /// <summary>
        /// APP Idling, when set it controls backend to idler
        /// </summary>
        internal bool Running
        {
            get => _running;
            private set
            {
                if (value) { 
                    StartTime = DateTime.Now;
                    Title = ToString();
                    APIThread.Start();
                } else {
                    Environment.SetEnvironmentVariable("SteamAppId", "");
                    StartTime = null;
                    Title = "Unknown game";
                    if (APIThread != null) APIThread.Abort();
                    ID = 0;
                }

                _running = value;
            }
        }

        /// <summary>
        /// APP API Thread
        /// </summary>
        internal Thread APIThread { get; private set; }

        /// <summary>
        /// Login user into steam and starts idling (APP ID must be set first)
        /// </summary>
        internal bool Connect => Login();

        /// <summary>
        /// Logut user from steam and stop and idling
        /// </summary>
        internal bool Disconnect => Logout();

        /// <summary>
        /// API Key
        /// </summary>
        private string? APIkey { get; set; }

        /// <summary>
        /// Validates API Key
        /// </summary>
        internal bool APIkeyValid => !string.IsNullOrWhiteSpace(APIkey);
        
        /// <summary>
        /// API Wrapper
        /// </summary>
        internal PlayerService? InterfacePlayerService { get; private set; }
        
        /// <summary>
        /// Check if API is connected yet 
        /// </summary>
        internal bool APIConnected => APIkeyValid && InterfacePlayerService != null;

        /// <summary>
        /// Last API request
        /// </summary>
        internal TimeSpan APILastFetch = TimeSpan.FromTicks(DateTime.Now.Ticks);

        /// <summary>
        /// Last fetched APP playtime
        /// </summary>
        internal TimeSpan APIPlaytimeLastFetch = TimeSpan.FromTicks(DateTime.Now.Ticks);
       
        /// <summary>
        /// Check if can make a new API request
        /// </summary>
        internal bool APICanFetch => TimeSpan.FromTicks(DateTime.Now.Ticks) >= APILastFetch.Add(TimeSpan.FromSeconds(15));//API can fetch every 15 secs

        /// <summary>
        /// Check if can fetch APP playtime
        /// </summary>
        internal bool APICanFetchPlaytime => APICanFetch && TimeSpan.FromTicks(DateTime.Now.Ticks) >= APIPlaytimeLastFetch.Add(TimeSpan.FromMinutes(5));//API can fetch playtime every 5 mins

        /// <summary>
        /// All Games user owns
        /// </summary>
        /// <returns></returns>
        internal IReadOnlyCollection<OwnedGameModel> UserGames()
        {
            APILastFetch = TimeSpan.FromTicks(DateTime.Now.Ticks);
            return InterfacePlayerService.GetOwnedGamesAsync(_steamUser015.GetSteamID().ConvertToUint64(), true, true).GetAwaiter().GetResult().Data.OwnedGames;
        }

        /// <summary>
        /// Gets user information for APPID
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        internal OwnedGameModel GetGameInfo(uint appID) => APICanFetch ? UserGames().Where(g => g.AppId == appID).ToList()[0] : null;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="apikey"></param>
        internal SteamApp(uint appID, string apikey = "")
        {
            ID = appID;
            APIkey = apikey;

            //bad APP ID
            if (!IDValid) return;

            //setup API
            if (APIkeyValid) InterfacePlayerService = new PlayerService(apikey);

            //Create API Thread too periodically fetch data from steam
            APIThread = !APIConnected ? null : new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                 
                while (IDSet)
                {
                    var title1 = $"Idling \"{Title}\" [{ID}] | Uptime: {UpTime}";
                    var title2 = "";

                    //Fetch playtime
                    if(APICanFetchPlaytime || (Playtime == 0 && APICanFetch))
                    {
                        Console.Title = string.Format("Steam API Request: Fetching User Info For AppID ({0})", ID);

                        //get user game info
                        var game = GetGameInfo(ID);
                            
                        if(game != null)
                        {
                            //set title
                            var name = game.Name;
                            if (Title != name) Title = name;

                            //set image url
                            if (ImageUrl == "") ImageUrl = string.Format("http://media.steampowered.com/steamcommunity/public/images/apps/{0}/{1}.jpg", game.AppId, game.ImgLogoUrl);

                            //set playtime
                            var playtime = Math.Round(game.PlaytimeForever.TotalHours, 0);
                            if (Playtime != playtime)
                            {
                                if (Playtime != 0) Console.WriteLine($"{name} Total Hours: {playtime}hrs");
                                Playtime = playtime;
                            }

                            Thread.Sleep(1 * 1000);
                            Console.Title = string.Format("Steam API Request: Succses Fetching AppID ({0}) User Info", ID);
                            Thread.Sleep(1 * 1000);
                        }

                        APIPlaytimeLastFetch = TimeSpan.FromTicks(DateTime.Now.Ticks);
                    }

                    //compose title 2
                    if (Playtime != 0) title2 = $"Total Hours: {Playtime}";
                    
                    
                    //update Console
                    Console.Title = Running ? title2 == "" ? title1 : $"{title1} | {title2}" : "HourBoostr";

                    Thread.Sleep(1 * 900);
                }
            });
        }

        /// <summary>
        /// Constructs APP Name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder(128);
            _steamApps001.GetAppData(ID, "name", sb);
            string gameName = sb.ToString().Trim();
            return string.IsNullOrWhiteSpace(gameName) ? "Unknown game" : Encoding.UTF8.GetString(Encoding.Default.GetBytes(gameName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool Login()
        {
            bool ShowError(string str)
            {
                Console.WriteLine($"ERROR: {str}\n\nPress any key to exit...");
                Console.ReadKey();
                return false;
            }

            //set appID to emulate as playing
            Environment.SetEnvironmentVariable("SteamAppId", ID.ToString());
            Console.WriteLine("AppID Set");

            //start steamworks
            if (!Steamworks.Load(true)) return ShowError("Steamworks failed to load.");
            if (Environment.CurrentDirectory == Steamworks.GetInstallPath()) return ShowError("You are not allowed to run this application from the Steam directory folder.");
            Console.WriteLine("Steamworks Loaded");

            //setup interfaces
            _steamClient012 = Steamworks.CreateInterface<ISteamClient012>();
            Console.WriteLine("Interfaces Created");

            //create pipe
            int pipe = _steamClient012.CreateSteamPipe();
            if (pipe == 0) return ShowError("Failed to create Steam pipe.");
            Console.WriteLine("Steam Pipe Created");

            //connect to user
            int user = _steamClient012.ConnectToGlobalUser(pipe);
            if (user == 0) return ShowError("Failed to connect to Steam user.");

            _steamUser015 = _steamClient012.GetISteamUser<ISteamUser015>(user, pipe);
            _steamApps001 = _steamClient012.GetISteamApps<ISteamApps001>(user, pipe);
            
            Console.WriteLine($"Steam user \"{_steamClient012.GetISteamFriends<ISteamFriends002>(user, pipe).GetPersonaName()}\" [{_steamUser015.GetSteamID().ConvertToUint64()}] Connected");
              
            //
            Thread.Sleep(2 * 1000);
            Running = _steamUser015 != null && _steamApps001 != null;

            return Running;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool Logout()
        {
            Running = false;
            return true;
        }
    } 
}