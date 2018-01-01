using Steam4NET;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace SingleBoostrGame
{
    class Program
    {
        private static ISteamClient012 _steamClient012;
        private static ISteamApps001 _steamApps001;

        private const int _secondsBetweenChecks = 15;
        private static BackgroundWorker _bwg;

        private static void _bwg_DoWork(object sender, DoWorkEventArgs e)
        {
            var processList = Process.GetProcesses();
            var parentProcess = processList.FirstOrDefault(o => o.Id == (int)e.Argument);

            if (parentProcess == null)
            {
                Console.WriteLine($"Could not find parent ID. Exiting in {_secondsBetweenChecks} seconds.");
                Thread.Sleep(TimeSpan.FromSeconds(_secondsBetweenChecks));
            }
            else
            {
                while (!_bwg.CancellationPending)
                {
                    if (parentProcess.HasExited)
                        break;

                    Thread.Sleep(TimeSpan.FromSeconds(_secondsBetweenChecks));
                }
            }
            
            Environment.Exit(1);
        }

        private static string GetUnicodeString(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Encoding.UTF8.GetString(bytes);
        }

        private static void ShowError(string str)
        {
            Console.WriteLine($"ERROR: {str}\n\nPress any key to exit...");
            Console.ReadKey();
        }

        private static void SetConsoleWindowName(uint appId)
        {
            var sb = new StringBuilder(60);
            _steamApps001.GetAppData(appId, "name", sb);

            string gameName = sb.ToString().Trim();
            Console.Title = string.IsNullOrWhiteSpace(gameName) ? "Unknown game" : GetUnicodeString(gameName);
        }

        private static bool ConnectToSteam()
        {
            if (!Steamworks.Load(true))
            {
                ShowError("Steamworks failed to load.");
                return false;
            }

            _steamClient012 = Steamworks.CreateInterface<ISteamClient012>();
            if (_steamClient012 == null)
            {
                ShowError("Failed to create Steam Client inferface.");
                return false;
            }

            int pipe = _steamClient012.CreateSteamPipe();
            if (pipe == 0)
            {
                ShowError("Failed to create Steam pipe.");
                return false;
            }

            int user = _steamClient012.ConnectToGlobalUser(pipe);
            if (user == 0)
            {
                ShowError("Failed to connect to Steam user.");
                return false;
            }

            _steamApps001 = _steamClient012.GetISteamApps<ISteamApps001>(user, pipe);
            if (_steamApps001 == null)
            {
                ShowError("Failed to create Steam Apps inferface.");
                return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            _bwg = new BackgroundWorker() { WorkerSupportsCancellation = true };
            _bwg.DoWork += _bwg_DoWork;
            
            uint appId = 0;
            if (args.Length == 0)
            {
                do Console.WriteLine("Enter appId of game you wish to boost:");
                while (!uint.TryParse(Console.ReadLine().Trim(), out appId));
            }
            else
            {
                if (!uint.TryParse(args[0], out appId))
                {
                    ShowError($"Unable to parse '{args[0]}' as an app id.");
                    return;
                }
            }

            Environment.SetEnvironmentVariable("SteamAppId", appId.ToString());

            if (ConnectToSteam())
            {
                SetConsoleWindowName(appId);

                int parentProcessId = -1;
                if (args.Length >= 2 && int.TryParse(args[1], out parentProcessId) && parentProcessId != -1)
                    _bwg.RunWorkerAsync(parentProcessId);

                Console.Clear();
                Console.WriteLine("Running! Press any key or close window to stop idling.");
                Console.ReadKey();

                if (_bwg.IsBusy)
                    _bwg.CancelAsync();
            }
        }
    }
}
