using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SingleBoostr.Core.Objects
{
    public class SteamApp : IComparable<SteamApp>
    {
        private Steam Base { get; set; } = null;
        public Process Process { get; set; }

        public uint ID { get; private set; } = 0;
        public string Title => this.ToString();
        public string ImageUrl => $"http://cdn.akamai.steamstatic.com/steam/apps/{ID}/header.jpg";
        public string CardUrl => $"{Base.ProfileUrl}/{Base.Steam64ID}/gamecards/{ID}";
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
        public List<TradingCard> Cards { get; set; } = new List<TradingCard>() { };

        public SteamApp(Steam steam, uint appID)
        {
            ID = appID;
            Base = steam;

            if(IDValid) Environment.SetEnvironmentVariable("SteamAppId", ID.ToString());
        }

        public async Task Start()
        {

            Running = true;
        }
        public async Task Stop()
        {

            Running = false;
        }
        private string GetName()
        {
            var sb = new StringBuilder(128);
            Base.SteamApps001.GetAppData(ID, "name", sb);
            string gameName = sb.ToString().Trim();
            return string.IsNullOrWhiteSpace(gameName) ? "Unknown game" : Encoding.UTF8.GetString(Encoding.Default.GetBytes(gameName));
        }
        public string GetIDAndName() => $"{ID} | {Title}";
        public int CompareTo(SteamApp other) => Title.CompareTo(other.Title); 
        public override string ToString() => GetName();
    }
}