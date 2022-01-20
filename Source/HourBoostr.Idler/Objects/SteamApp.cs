using System;
using System.Diagnostics;
using System.Text;

namespace HourBoostr.Idler.Objects
{
    public class SteamApp : IComparable<SteamApp>
    {
        public Process Process { get; set; }

        public uint ID { get; init; }
        public string Title => GetName();
        public string ImageUrl => $"http://cdn.akamai.steamstatic.com/steam/apps/{ID}/header.jpg";
        public double Playtime { get; set; } = 0;
        public DateTime? StartTime { get; private set; }
        private bool _running = false;
        public bool Running
        {
            get => _running;
            private set
            {
                if (value)
                {
                    StartTime = DateTime.Now;
                    Environment.SetEnvironmentVariable("SteamAppId", ID.ToString());
                }
                else Environment.SetEnvironmentVariable("SteamAppId", "");
                _running = value;
            }
        }
        public string UpTime => (DateTime.Now - StartTime).ToString().Split(new[] { '.' })[0];
        public bool IDValid => !string.IsNullOrWhiteSpace(ID.ToString()) && ID > 0;
        public bool IDSet => IDValid && Environment.GetEnvironmentVariable("SteamAppId") == ID.ToString();

        public SteamApp(uint appID) => ID = appID;

        public void Start() => Running = true;
        public void Stop() => Running = false;
        private string GetName()
        {
            var sb = new StringBuilder(128);
            Program.This.SteamApps001.GetAppData(ID, "name", sb);
            string gameName = sb.ToString().Trim();
            return string.IsNullOrWhiteSpace(gameName) ? "Unknown game" : Encoding.UTF8.GetString(Encoding.Default.GetBytes(gameName));
        }
        public string GetIDAndName() => $"{ID} | {Title}";
        public int CompareTo(SteamApp other) => Title.CompareTo(other.Title);
        public override string ToString() => GetName();
    }
}