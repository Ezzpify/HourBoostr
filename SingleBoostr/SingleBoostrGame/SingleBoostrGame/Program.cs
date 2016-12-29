using System;
using SingleBoostr;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;

namespace SingleBoostrGame
{
    /*

        SingleBoostr.Game
        -----------------

        Takes 3 arguments
            appId (long)
            appName (string) (optional)
            parentProcessId (int) (optional)

        If parentProcessId is specified then if parent process dies unexpectedly
        then all children spawned will kill themselves as well.

        If not specified then the children will live as orphans.
        Useful if you want to launch this from command line instead of using the main app.

    */

    class Program
    {
        private static int _parentProcessId = -1;
        private static BackgroundWorker _bwg;
        private static bool _enabled;

        private static void _bwg_DoWork(object sender, DoWorkEventArgs e)
        {
            var parentProcess = Process.GetProcessById(_parentProcessId);
            if (parentProcess == null)
                return;

            while (_enabled)
            {
                try
                {
                    parentProcess.Refresh();
                    if (parentProcess.HasExited)
                        break;
                }
                catch
                {
                    break;
                }

                Thread.Sleep(TimeSpan.FromSeconds(30));
            }

            Environment.Exit(1);
        }

        private static void restInfo(string[] args)
        {
            if (args.Length == 2)
            {
                Console.Title = args[1];
            }
            
            if (args.Length == 3 && int.TryParse(args[2], out _parentProcessId))
            {
                if (_parentProcessId == -1)
                    return;

                _enabled = true;
                _bwg = new BackgroundWorker();
                _bwg.DoWork += _bwg_DoWork;

                _bwg.RunWorkerAsync();
            }
        }
        
        static void Main(string[] args)
        {
            long appId = 0;
            if (args.Length > 0 && long.TryParse(args[0], out appId))
            {
                if (appId == 0)
                    return;

                var client = new Client();
                if (client.Initialize(appId))
                {
                    restInfo(args);
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Title = "SingleBoostr.Game :: Missing arguments";
                Console.WriteLine("Missing arguments:\n - appId (long)\n - gameName (string) (opional)\n - parentProcessId (int) (optional)");
                Console.WriteLine("\n\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
