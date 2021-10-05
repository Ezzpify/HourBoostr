using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace SingleBoostr.Game.Misc
{
    internal class AppBackgroundWorker
    {
        private const int SecondsBetweenChecks = 5;
        internal BackgroundWorker Instance;
        internal AppBackgroundWorker()
        {
            Instance = new BackgroundWorker() { WorkerSupportsCancellation = true };
            Instance.DoWork += DoWork;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            var parentProcess = Process.GetProcesses().FirstOrDefault(o => o.Id == (int)e.Argument);

            if (parentProcess == null)
            {
                Console.WriteLine($"Could not find parent ID. Exiting in {SecondsBetweenChecks} seconds.");
                Thread.Sleep(TimeSpan.FromSeconds(SecondsBetweenChecks));
            } else {
                while (!Instance.CancellationPending)
                {
                    if (parentProcess.HasExited) break;
                    Thread.Sleep(TimeSpan.FromSeconds(SecondsBetweenChecks));
                }
            }
            Environment.Exit(1);
        }
    }
}