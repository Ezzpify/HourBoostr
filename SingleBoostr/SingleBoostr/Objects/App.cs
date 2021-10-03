using System;
using System.Diagnostics;
using SingleBoostr.objects;

namespace SingleBoostr
{
    public class App : IComparable<App>
    {
        public uint appid { get; set; }
        public string name { get; set; }
        public Process process { get; set; }
        public TradeCard card { get; set; }

        public int CompareTo(App other) => name.CompareTo(other.name);
        public string GetIdAndName() => $"{appid} | {name}";
    }
}
