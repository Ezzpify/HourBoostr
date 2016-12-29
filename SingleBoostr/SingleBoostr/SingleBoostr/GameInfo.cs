using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleBoostr
{
    public class GameInfo : IComparable<GameInfo>
    {
        public long appId { get; set; }

        public string name { get; set; }

        public int CompareTo(GameInfo other)
        {
            return name.CompareTo(other.name);
        }
    }
}
