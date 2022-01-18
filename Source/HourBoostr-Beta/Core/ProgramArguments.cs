using System.Collections.Generic;
using System.Linq; 

namespace HourBoostr_Beta.Core
{
    internal class ProgramArguments
    {
        internal bool DevMode { get; private set; } = false;

        internal ProgramArguments(List<string> arguments)
        {
            if (arguments.Any())
            {
                var mode = arguments.First().Replace("-", "");

                switch (mode)
                {
                    case "dev": DevMode = true; break;
                }
            }
        }
    }
}
