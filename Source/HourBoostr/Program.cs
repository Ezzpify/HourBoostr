using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace HourBoostr
{
    public class Program
    {
        /// <summary>
        /// Global database
        /// </summary>
        internal static  GlobalDB mGlobalDB;
        
        /// <summary>
        /// Our session
        /// </summary>
        private static Session mSession;
         
        /// <summary>
        /// Main function
        /// </summary>
        public static void Main() => AsyncContext.Run(() => MainAsync());

        /// <summary>
        /// Boostr startup method
        /// </summary>
        private protected static async Task MainAsync()
        {
            /*Create a folder for our account sentry files*/
            Console.Title = SingleBoostr.Core.Misc.Const.HourBoostr.CONSOLE_TITLE;
            Directory.CreateDirectory(SingleBoostr.Core.Misc.Const.HourBoostr.SENTRY_FOLDER);
            Directory.CreateDirectory(SingleBoostr.Core.Misc.Const.HourBoostr.LOG_FOLDER);
            
            /*Load global database*/
            mGlobalDB = GlobalDB.Load(SingleBoostr.Core.Misc.Const.HourBoostr.GLOBAL_SETTINGS_FILE);
            if (mGlobalDB == null)
            {
                Console.WriteLine($"Error loading global db at {SingleBoostr.Core.Misc.Const.HourBoostr.GLOBAL_SETTINGS_FILE}. Delete file if problem is consistent.");
            }
            else
            {
                if (mGlobalDB.CellID == 0)
                    mGlobalDB.CellID = 66;
                 
                /*Read the application settings and start our session*/
                var settings = Settings.GetSettings();
                if (settings != null)
                {
                    if (settings.Accounts.Count > 0)
                    {
                        mSession = new Session(settings);
                        var running = await mSession.Startup(); 
                        if(!running) Console.WriteLine("Error loading Boostr");
                        while (mSession.mBwg.IsBusy)
                            Thread.Sleep(250);
                    }
                    else
                    {
                        Console.WriteLine("No accounts were loaded from settings. Press any key to exit.");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}