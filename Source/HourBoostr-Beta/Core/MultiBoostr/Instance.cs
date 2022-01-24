using System;
using System.Collections.Generic;

namespace HourBoostr_Beta.Core.MultiBoostr
{
    internal class Instance
    {
        internal int processID { get; init; } //property is Immutable and cannot be changed once object is created
        internal Instance(List<BoostrAccount> accounts)
        {

        }

        public void Exit(object sender, EventArgs e)
        {

        }
    }
}
