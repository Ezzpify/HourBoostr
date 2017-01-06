using System;
using SingleBoostr;
using System.ComponentModel;
using System.Threading;
using System.Text;
using System.Diagnostics;

namespace SingleBoostrGame
{
    /*

        SingleBoostr.Game
        -----------------

        Takes 3 arguments
            appId (long)
            achievments (int)
            appName (string) (optional)
            parentProcessId (int) (optional)

        If parentProcessId is specified then if parent process dies unexpectedly
        then all children spawned will kill themselves as well.

        If not specified then the children will live as orphans.
        Useful if you want to launch this from command line instead of using the main app.

    */

    class Program
    {
        private static int _parentProcessId = 0;
        private static int _processErrors = 0;
        private static BackgroundWorker _bwg;
        private static Client _steamClient;

        private static void _bwg_DoWork(object sender, DoWorkEventArgs e)
        {
            var parentProcess = Process.GetProcessById(_parentProcessId);
            if (parentProcess != null)
            {
                while (!_bwg.CancellationPending)
                {
                    try
                    {
                        parentProcess.Refresh();
                        if (parentProcess.HasExited)
                            break;
                    }
                    catch
                    {
                        if (++_processErrors >= 3)
                            break;
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(15));
                }
            }

            Environment.Exit(1);
        }

        private static string getUnicodeString(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Encoding.UTF8.GetString(bytes);
        }

        static void Main(string[] args)
        {
            long appId = 0;
            if (args.Length >= 1 && long.TryParse(args[0], out appId))
            {
                if (appId == 0)
                    return;

                _steamClient = new Client();
                if (_steamClient.Initialize(appId))
                {
                    string gameName = _steamClient.SteamApps001.GetAppData((uint)appId, "name").Trim();
                    Console.Title = string.IsNullOrWhiteSpace(gameName) ? "Unknown game" : getUnicodeString(gameName);

                    if (args.Length >= 2 && int.TryParse(args[1], out _parentProcessId))
                    {
                        if (_parentProcessId == 0)
                            return;

                        _bwg = new BackgroundWorker() { WorkerSupportsCancellation = true };
                        _bwg.DoWork += _bwg_DoWork;
                        _bwg.RunWorkerAsync();
                    }

                    Console.WriteLine("Running! Press any key or close window to stop idling.");
                    Console.ReadKey();

                    if (_bwg != null && _bwg.IsBusy)
                        _bwg.CancelAsync();
                }
            }
            else
            {
                Console.Title = "SingleBoostr.Game :: Missing arguments";
                Console.WriteLine("Missing arguments:\n - appId (long)\n - parentProcessId (int) (optional)");
                Console.WriteLine("\n\nPress any key to exit...");
                Console.ReadKey();
            }

            Environment.Exit(1);
        }
    }
}
