using System.Collections.Generic;
using System.Linq;

namespace HourBoostr.Idler.Core
{
    internal class ProgramArguments
    {
        internal bool MultiBoostr { get; init; }
        internal string AppID { get; init; }

        internal ProgramArguments(List<string> arguments)
        {
            if (arguments.Any())
            {
                var index = 0;
                foreach (var arg in arguments)
                {
                    if (!arg.StartsWith("-")) continue;

                    switch (arg.ToLower().Replace("-", ""))
                    {
                        case "multi": MultiBoostr = true; continue;
                        case "single":
                            if (arguments.Count == 2)
                            {
                                AppID = arguments[index + 1];
                            }
                            continue;
                    }

                    index++;
                }
            }
        }
    }
}
