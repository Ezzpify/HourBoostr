using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace HourBoostr
{
    class Program
    {
        #region Imports

        /// <summary>
        /// DllImport for setting foreground of a window
        /// </summary>
        /// <param name="hWnd">Hwnd of window to manage</param>
        /// <returns>Returns bool</returns>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        /// <summary>
        /// DllImport for getting current console window intptr
        /// </summary>
        /// <returns>Returns IntPtr</returns>
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();


        /// <summary>
        /// DllImport for showing/hiding window
        /// </summary>
        /// <param name="hWnd">Hwnd of window to manage</param>
        /// <param name="nCmdShow">Show parameter</param>
        /// <returns>Returns bool</returns>
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        /// <summary>
        /// DllImport to catch the exit event
        /// </summary>
        /// <returns>Returns bool</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
        private delegate bool ConsoleEventDelegate(int eventType);

        #endregion Imports


        /// <summary>
        /// Application tray icon
        /// Used for hiding/showing the application in a click
        /// </summary>
        static private NotifyIcon mTrayIcon = new NotifyIcon();


        /// <summary>
        /// Console event handler
        /// </summary>
        static private ConsoleEventDelegate mEventHandler;


        /// <summary>
        /// Application settings
        /// </summary>
        static private Config.Settings mSettings;


        /// <summary>
        /// Thread variables
        /// </summary>
        static private Thread mThreadTray;


        /// <summary>
        /// Global database
        /// </summary>
        static public GlobalDB mGlobalDB;


        /// <summary>
        /// Our session
        /// </summary>
        static private Session mSession;


        /// <summary>
        /// Represents if the console is hidden
        /// </summary>
        static private bool mIsHidden;


        /// <summary>
        /// HACK HACK!
        /// Initialize the tray icon thread
        /// Keep it running
        /// </summary>
        static private void ToTray()
        {
            /*Set TrayIcon information*/
            mTrayIcon.Text = "HourBoostr\nClick to Show/Hide";
            mTrayIcon.Icon = Properties.Resources.icon;
            mTrayIcon.Click += new EventHandler(TrayIcon_Click);
            mTrayIcon.Visible = true;
            Application.Run();

            /*To keep TrayIcon from dissapearing, 
              we need to keep the thread running*/
            while (true) { Thread.Sleep(250); }
        }


        /// <summary>
        /// TrayIcon click event
        /// Show/Hide the window depending on its state
        /// </summary>
        static private void TrayIcon_Click(object sender, EventArgs e)
        {
            ShowConsole(mIsHidden);
        }


        /// <summary>
        /// Show/Hide the console window
        /// </summary>
        /// <param name="show">True to show, false to hide</param>
        static private void ShowConsole(bool show)
        {
            if (show)
            {
                ShowWindow(GetConsoleWindow(), 5);
                SetForegroundWindow(GetConsoleWindow());
            }
            else
            {
                ShowWindow(GetConsoleWindow(), 0);
            }

            mIsHidden = !show;
        }


        /// <summary>
        /// Catch exit event
        /// Realistically we have 4-5 seconds to preform this
        /// action before windows forces the program to close
        /// </summary>
        /// <param name="eventType">Event type</param>
        /// <returns>Returns bool</returns>
        static bool ConsoleEventCallback(int eventType)
        {
            /*eventType 2 being Exit event*/
            if (eventType == 2)
            {
                if (mSession != null)
                {
                    /*Disconnect all clients*/
                    Console.WriteLine("\n\nDisconnecting...");
                    foreach (var Bot in mSession.mActiveBotList)
                    {
                        Bot.mIsRunning = false;
                        Bot.mSteam.client.Disconnect();
                    }

                    /*Update settings*/
                    if (Settings.UpdateSettings(mSettings, mSession.mSettings))
                        Console.WriteLine("Updated user settings");
                }

                mTrayIcon.Visible = false;
                mTrayIcon.Dispose();

                Console.WriteLine("Exiting...");
                Thread.Sleep(500);
            }

            return false;
        }


        /// <summary>
        /// Main function
        /// Too many comments
        /// </summary>
        /// <param name="args">No args</param>
        static void Main(string[] args)
        {
            /*Create a folder for our account sentry files*/
            Console.Title = EndPoint.CONSOLE_TITLE;
            Directory.CreateDirectory(EndPoint.SENTRY_FOLDER_PATH);
            Directory.CreateDirectory(EndPoint.LOG_FOLDER_PATH);

            /*Set exit events so we'll log out all accounts if application is exited*/
            mEventHandler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(mEventHandler, true);

            /*Start the trayicon thread*/
            mThreadTray = new Thread(ToTray);
            mThreadTray.Start();

            /*We'll read and store the settings twice since we'll compare the two objects later on
            to see if something has changed by the user during runtime*/
            mSettings = Settings.GetSettings();
            if (mSettings == null)
                return;

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

                        if (settings.HideToTrayAutomatically)
                        {
                            mTrayIcon.ShowBalloonTip(1000, "HourBoostr", "I'm down here!", ToolTipIcon.Info);
                            ShowConsole(false);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No accounts were loaded from settings.");
                    }

                    while (true)
                        Thread.Sleep(250);
                }
            }
        }
    }
}