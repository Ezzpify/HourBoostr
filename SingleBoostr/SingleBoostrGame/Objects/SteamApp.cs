using Steam4NET;
using System;
using System.Text;

namespace SingleBoostrGame
{
    internal class SteamApp
    {
        private ISteamClient012 _steamClient012;
        private ISteamApps001 _steamApps001;

        internal uint ID = 0;
        internal string Title = "Unknown game";
        internal DateTime StartTime { get; set; }
        internal string UpTime => (DateTime.Now - StartTime).ToString().Split(new[] { '.' })[0];
        private bool _running = false;
        internal bool Running
        {
            get => _running;
            private set
            {
                if (value) StartTime = DateTime.Now;
                Title = value ? ToString() : "Unknown game";
                _running = value;
            }
        }
        internal SteamApp(uint appID)
        {
            ID = appID;
            Environment.SetEnvironmentVariable("SteamAppId", ID.ToString());
        }

        public override string ToString()
        {
            var sb = new StringBuilder(128);
            _steamApps001.GetAppData(ID, "name", sb);
            string gameName = sb.ToString().Trim();
            return string.IsNullOrWhiteSpace(gameName) ? "Unknown game" : Encoding.UTF8.GetString(Encoding.Default.GetBytes(gameName));
        }

        internal bool Connect()
        {
            void ShowError(string str)
            {
                Console.WriteLine($"ERROR: {str}\n\nPress any key to exit...");
                Console.ReadKey();
            }

            if (!Steamworks.Load(true))
            {
                ShowError("Steamworks failed to load.");
                return false;
            }

            _steamClient012 = Steamworks.CreateInterface<ISteamClient012>();
            if (_steamClient012 == null)
            {
                ShowError("Failed to create Steam Client inferface.");
                return false;
            }

            int pipe = _steamClient012.CreateSteamPipe();
            if (pipe == 0)
            {
                ShowError("Failed to create Steam pipe.");
                return false;
            }

            int user = _steamClient012.ConnectToGlobalUser(pipe);
            if (user == 0)
            {
                ShowError("Failed to connect to Steam user.");
                return false;
            }

            _steamApps001 = _steamClient012.GetISteamApps<ISteamApps001>(user, pipe);
            if (_steamApps001 == null)
            {
                ShowError("Failed to create Steam Apps inferface.");
                return false;
            }
            else Running = true;

            return Running;
        }
    } 
}
