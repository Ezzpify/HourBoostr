using System;
using System.Text;
using System.Threading.Tasks;

namespace SingleBoostr.Core.Objects
{
    public class SteamApp
    {
        private Steam Base { get; set; } = null;
        public uint ID { get; private set; } = 0;
        public string Title => this.ToString();
        public string ImageUrl { get; set; } = "";
        public double Playtime { get; set; } = 0;
        public DateTime? StartTime { get; private set; }
        private bool _running = false;
        public bool Running
        {
            get => _running;
            private set
            {
                if (value) StartTime = DateTime.Now;
                else Environment.SetEnvironmentVariable("SteamAppId", "");
                _running = value;
            }
        }

        public string UpTime => (DateTime.Now - StartTime).ToString().Split(new[] { '.' })[0];
        public bool IDValid => !string.IsNullOrWhiteSpace(ID.ToString()) && ID > 0;
        public bool IDSet => IDValid && Environment.GetEnvironmentVariable("SteamAppId") == ID.ToString();

        public SteamApp(Steam steam, uint appID)
        {
            ID = appID;
            Base = steam;

            if(IDValid) Environment.SetEnvironmentVariable("SteamAppId", ID.ToString());
        }

        public override string ToString()
        {
            var sb = new StringBuilder(128);
            Base.SteamApps001.GetAppData(ID, "name", sb);
            string gameName = sb.ToString().Trim();
            return string.IsNullOrWhiteSpace(gameName) ? "Unknown game" : Encoding.UTF8.GetString(Encoding.Default.GetBytes(gameName));
        }

        public async Task Start()
        {

            Running = true;
        }

        public async Task Stop()
        {

            Running = false;
        }
    }
} 