using Steam4NET;
using SteamWebAPI2.Interfaces;
using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Steam.Models.SteamCommunity;
using System.Collections.Generic;
using System.Threading.Tasks;
using SingleBoostr.Core.Misc;
using System.Text;

namespace SingleBoostr.Core.Objects
{
    public class Steam
    {
        public ISteam006 Steam006 { get; private set; }
        public IClientUser ClientUser { get; private set; }
        public ISteamApps001 SteamApps001 { get; private set; }
        public ISteamApps003 SteamApps003 { get; private set; }
        public IClientEngine ClientEngine { get; private set; }
        public ISteamUser015 SteamUser015 { get; private set; }
        public ISteamUser016 SteamUser016 { get; private set; }
        public ISteamClient012 SteamClient012 { get; private set; }
        public ISteamFriends002 SteamFriends002 { get; private set; }

        public int User { get; private set; }
        public int Pipe { get; private set; }
        public string APIKey { private get; set; } = null;
        public bool APIkeyValid => !string.IsNullOrEmpty(APIKey);

        public string DisplayName => Utils.GetUnicodeString(SteamFriends002.GetPersonaName());
        // public ulong Steam64ID => SteamUser015.GetSteamID().ConvertToUint64();
        public ulong Steam64ID => SteamUser016.GetSteamID().ConvertToUint64();
        public string ProfileUrl => $"http://steamcommunity.com/profiles/{Steam64ID}";
         
        public string GetFriendName(CSteamID senderId) => senderId != Steam64ID ? SteamFriends002.GetFriendPersonaName(senderId) : DisplayName;
        public bool AddFriend(string emailOrAccountName) => SteamFriends002.AddFriendByName(emailOrAccountName) > -1;
        public bool AddFriend(CSteamID senderId) => senderId != Steam64ID ? SteamFriends002.AddFriend(senderId) : false;
        public bool RemoveFriend(CSteamID senderId) => senderId != Steam64ID ? SteamFriends002.RemoveFriend(senderId) : false;
        public bool SendFriendMessage(CSteamID receiver, string message) => SteamFriends002.SendMsgToFriend(receiver, EChatEntryType.k_EChatEntryTypeChatMsg, Encoding.UTF8.GetBytes(message));
       
        public TSteamError steamError = new TSteamError();

        public PlayerService InterfacePlayerService { get; private set; } = null;
        public bool APIConnected => APIkeyValid && InterfacePlayerService != null;
        public TimeSpan APILastFetch = TimeSpan.FromTicks(DateTime.Now.Ticks);
        public TimeSpan APIPlaytimeLastFetch = TimeSpan.FromTicks(DateTime.Now.Ticks);
        public bool APICanFetch => TimeSpan.FromTicks(DateTime.Now.Ticks) >= APILastFetch.Add(TimeSpan.FromSeconds(15));//API can fetch every 15 secs
        public bool APICanFetchPlaytime => APICanFetch && TimeSpan.FromTicks(DateTime.Now.Ticks) >= APIPlaytimeLastFetch.Add(TimeSpan.FromMinutes(5));//API can fetch playtime every 5 mins

        public List<SteamApp> APPS = new List<SteamApp> { };
        public Thread APIThread { get; private set; } = null;

        public IReadOnlyCollection<OwnedGameModel> UserGames()
        {
            APILastFetch = TimeSpan.FromTicks(DateTime.Now.Ticks);
            return InterfacePlayerService.GetOwnedGamesAsync(Steam64ID, true, true).GetAwaiter().GetResult().Data.OwnedGames;
        }

        public OwnedGameModel GetGameInfo(uint appID) => UserGames().Where(g => g.AppId == appID).First();
 
        public Steam(string apikey = "", uint appID = 0)
        {
            //setup API
            APIKey = apikey;
            if (APIkeyValid) InterfacePlayerService = new PlayerService(APIKey);

            //setup app to idle
            if (appID > 0)
            {
                var app = new SteamApp(this, appID);
                APPS.Add(app);
            }

            //Create API Thread too periodically fetch data from steam
            APIThread = !APIConnected || !APPS.Any() ? null : new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Console.WriteLine("API Thread: Started");

                var firstload = true;

                while (APPS.Any())
                {
                    //Fetch playtime
                    if (APICanFetchPlaytime || (firstload && APICanFetch))
                    {
                        foreach (SteamApp APP in APPS)
                        { 
                            Console.WriteLine("API Thread: Fetching Playtime");

                            //get user game info
                            var game = GetGameInfo(APP.ID);

                            if (game != null)
                            {
                                //set playtime
                                var playtime = Math.Round(game.PlaytimeForever.TotalHours, 0);
                                if (APP.Playtime != playtime) APP.Playtime = playtime;
                            }

                            APIPlaytimeLastFetch = TimeSpan.FromTicks(DateTime.Now.Ticks);
                            firstload = false;
                        }
                    }
                    
                    Thread.Sleep(5 * 1000);
                }
            });
        }

        public async Task<bool> Connect()
        {
            //Idler
            if (APPS.Count > 0) foreach (var APP in APPS) await APP.Start();

            //API
            if (APIThread != null) APIThread.Start();

            //Steamworks
            if (!Steamworks.Load(true)) return false; 
            if (Environment.CurrentDirectory == Steamworks.GetInstallPath()) return false;
             
            Steam006 = Steamworks.CreateSteamInterface<ISteam006>();
            if (Steam006.Startup(0, ref steamError) == 0) return false;

            SteamClient012 = Steamworks.CreateInterface<ISteamClient012>();
            if (SteamClient012 == null) return false;

            ClientEngine = Steamworks.CreateInterface<IClientEngine>();
            if (ClientEngine == null) return false;

            Pipe = SteamClient012.CreateSteamPipe();
            if (Pipe == 0) return false;

            User = SteamClient012.ConnectToGlobalUser(Pipe);
            if (User == 0 || User == -1) return false;

            SteamUser015 = SteamClient012.GetISteamUser<ISteamUser015>(User, Pipe);
            SteamUser016 = SteamClient012.GetISteamUser<ISteamUser016>(User, Pipe);
            ClientUser = ClientEngine.GetIClientUser<IClientUser>(User, Pipe);
            SteamApps001 = SteamClient012.GetISteamApps<ISteamApps001>(User, Pipe);
            SteamApps003 = SteamClient012.GetISteamApps<ISteamApps003>(User, Pipe);
            SteamFriends002 = SteamClient012.GetISteamFriends<ISteamFriends002>(User, Pipe);

            return SteamUser015 != null
                && SteamUser016 != null
                && ClientUser != null
                && SteamApps001 != null
                && SteamApps003 != null
                && SteamFriends002 != null;
        }

        public async Task Disconnect(bool terminate = true)
        {
            //Stop idler
            if (APPS.Count > 0) foreach (var APP in APPS) await APP.Stop();

            //Stop API
            if (APIThread != null) APIThread.Abort();

            //Kill App
            if (terminate) Environment.Exit(-1);
        }
    }
}