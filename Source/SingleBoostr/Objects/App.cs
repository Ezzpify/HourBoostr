using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SingleBoostr.Core.Misc;
using SingleBoostr.Core.Objects;  

namespace SingleBoostr
{
    public class App : IComparable<App>
    {
        public int Truncate { get; set; } = 60;
        public uint Appid { get; set; }
        public string Name { get; set; }
        public Process Process { get; set; }
        public TradingCard Card { get; set; }

        public int CompareTo(App other) => Name.CompareTo(other.Name);
        public string GetIdAndName() => Utils.Truncate($"{Appid} | {Name}", Truncate);
    }
}
