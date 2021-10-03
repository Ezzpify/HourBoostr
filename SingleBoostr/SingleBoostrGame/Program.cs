using System;
using SingleBoostr.Game.Core;

namespace SingleBoostrGame
{
    public class Program
    { 
        public static void Main(string[] args)
        { 
            uint appId;
            if (args.Length == 0)
            {
                do Console.WriteLine("Enter appId of game you wish to boost:");
                while (!uint.TryParse(Console.ReadLine().Trim(), out appId));
            }
            else
            {
                if (!uint.TryParse(args[0], out appId))
                { 
                    Console.WriteLine($"ERROR: Unable to parse '{args[0]}' as an app id.\n\nPress any key to exit...");
                    Console.ReadKey();
                    return;
                }
            }

            var steamApp = new SteamApp(appId);

            if (steamApp.Connect())
            {
                var appBackgroundWorker = new AppBackgroundWorker();

                Console.Title = $"Idling {steamApp.ToString()} - {steamApp.ID}";

                if (args.Length >= 2 && int.TryParse(args[1], out int parentProcessId) && parentProcessId != -1) appBackgroundWorker.Instance.RunWorkerAsync(parentProcessId);

                //wait
                Console.Clear();
                Console.WriteLine("Running! Press any key or close window to stop idling.");
                Console.ReadKey();

                //close
                if (appBackgroundWorker.Instance.IsBusy) appBackgroundWorker.Instance.CancelAsync();
            }
        }
    }
}
