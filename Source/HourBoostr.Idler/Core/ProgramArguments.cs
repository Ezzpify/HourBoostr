using System.Collections.Generic;
using System.Linq;

namespace HourBoostr.Idler.Core
{
    internal class ProgramArguments
    {
        private readonly string Param1Spliter = "-";
        internal bool MultiBoostr { get; init; }
        internal string AppID { get; init; }
        internal int ParentProcessID { get; init; } //property is Immutable and cannot be changed once object is created

        internal ProgramArguments(List<string> arguments)
        {
            if (arguments.Any())
            {
                var index = 0;
                foreach (var arg in arguments)
                {
                    if (!arg.StartsWith(Param1Spliter)) continue;
                     
                    var indexparam = index;

                    //argument 1
                    switch (arg.ToLower().Replace(Param1Spliter, ""))
                    {
                        case "multi": MultiBoostr = true; continue;
                        case "single":
                            if (arguments.Count < 2) continue;

                            //argument 2
                            indexparam++;
                            AppID = arguments[indexparam];
                            if (arguments.Count < 3) continue;

                            //argument 3
                            indexparam++;
                            if (int.TryParse(arguments[indexparam], out int parentProcessID))
                                ParentProcessID = parentProcessID;

                            continue;
                    }

                    index++;
                }
            }
        }
    }
}
