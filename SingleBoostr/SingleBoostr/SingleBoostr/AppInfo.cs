using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SingleBoostr
{
    public class App : IComparable<App>
    {
        public uint appid { get; set; }

        public string name { get; set; }

        public Process process { get; set; }

        public TradeCard card { get; set; }

        public int CompareTo(App other)
        {
            return name.CompareTo(other.name);
        }

        public string GetIdAndName()
        {
            return $"{appid} | {name}";
        }
    }

    public class TradeCard
    {
        public double minutesplayed { get; set; }

        public double price { get; set; }

        public int cardsremaining { get; set; }
    }

    public class Applist
    {
        public List<App> apps { get; set; }
    }

    public class SteamApps
    {
        public Applist applist { get; set; }
    }
}
