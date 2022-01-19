using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourBoostr_Beta.Core.MultiBoostr
{
    internal class Instance
    {
        internal int processID { get; init; } //property is Immutable and cannot be changed once object is created
        internal Instance(List<BoostrAccount> account)
        {

        }
    }
}
