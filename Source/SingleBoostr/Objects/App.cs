using System;
using System.Diagnostics;
using SingleBoostr.Core.Objects;
using SingleBoostr.objects;

namespace SingleBoostr
{
    public class App : IComparable<App>
    {
        public uint Appid { get; set; }
        public string Name { get; set; }
        public Process Process { get; set; }
        public TradingCard Card { get; set; }

        public int CompareTo(App other) => Name.CompareTo(other.Name);
        public string GetIdAndName() => $"{Appid} | {Name}";
    }
}
