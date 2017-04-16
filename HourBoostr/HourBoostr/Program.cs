using System;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace HourBoostr
{
    class Program
    {
        /// <summary>
        /// Global database
        /// </summary>
        static public GlobalDB mGlobalDB;


        /// <summary>
        /// Our session
        /// </summary>
        static private Session mSession;


        /// <summary>
        /// Main function
        /// Too many comments
        /// </summary>
        /// <param name="args">No args</param>
        [STAThread]
        static void Main(string[] args)
        {
            /*Create a folder for our account sentry files*/
            Console.Title = EndPoint.CONSOLE_TITLE;
            Directory.CreateDirectory(EndPoint.SENTRY_FOLDER_PATH);
            Directory.CreateDirectory(EndPoint.LOG_FOLDER_PATH);

            /*Load global database*/
            mGlobalDB = GlobalDB.Load(EndPoint.GLOBAL_SETTINGS_FILE_PATH);
            if (mGlobalDB == null)
            {
                Console.WriteLine($"Error loading global db at {EndPoint.GLOBAL_SETTINGS_FILE_PATH}. Delete file if problem is consistent.");
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