using System;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

namespace HourBoostr
{
    class Program
    {
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


        /// <summary>
        /// Private variables
        /// </summary>
        static private NotifyIcon mTrayIcon = new NotifyIcon();
        static private Commands mCommand = new Commands();
        static private ConsoleEventDelegate handler;
        static private Config.Settings mSettings;
        static private Session mSession;
        static private bool mIsHidden;


        /// <summary>
        /// Thread variables
        /// </summary>
        static private Thread mThreadTray;


        /// <summary>
        /// Reads the settings from file
        /// </summary>
        /// <returns>Returns false if failed</returns>
        static private bool ReadSettings()
        {
            /*Load settings if file exists, else create one*/
            string filePath = Path.Combine(Application.StartupPath, "Settings.json");
            if (!File.Exists(filePath))
            {
                /*Set up settings class to print*/
                Config.Settings settings = new Config.Settings();

                /*Add example accounts*/
                settings.Account.Add(new Config.AccountInfo());
                settings.Account.Add(new Config.AccountInfo());
                settings.Account.Add(new Config.AccountInfo());

                /*Write settings to file*/
                string settingsJson = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(filePath, settingsJson);
                Console.WriteLine("Settings.json has been written. Edit it for your accounts.");
                Thread.Sleep(1500);
            }
            else
            {
                try
                {
                    /*Load the settings from file*/
                    string settingsJson = File.ReadAllText(filePath);
                    mSettings = JsonConvert.DeserializeObject<Config.Settings>(settingsJson);
                    return true;
                }
                catch (JsonException jex)
                {
                    /*User fucked up with the formatting probably*/
                    MessageBox.Show("There was an error parsing Settings.json\n"
                        + "It's either incorrectly formatted or corrupt.\n"
                        + "Delete the file and let the app make a new one.\n\nError: " + jex.Message);
                }
            }

            return false;
        }


        /// <summary>
        /// Initializes our application
        /// </summary>
        /// <returns>Returns false if failed</returns>
        static private bool Initialize()
        {
            /*Create files and folders for our program*/
            Console.Title = "HourBoostr by Ezzy/Zute";
            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Sentryfiles"));

            /*Spawn new settings*/
            if (Properties.Settings.Default.UserInfo == null)
                Properties.Settings.Default.UserInfo = new StringCollection();

            /*Attempt to read the settings and start our session*/
            if (ReadSettings())
            {
                mSession = new Session(mSettings);
                return true;
            }

            return false;
        }


        /// <summary>
        /// HACK HACK!
        /// Initialize the tray icon thread
        /// Keep it running
        /// </summary>
        static private void ToTray()
        {
            /*Set TrayIcon information*/
            mTrayIcon.Text = "HourBoostr | \nClick to Show/Hide";
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static private void TrayIcon_Click(object sender, EventArgs e)
        {
            ShowConsole(!mIsHidden);
        }


        /// <summary>
        /// Show/Hide the console window
        /// </summary>
        /// <param name="b">Display console</param>
        static private void ShowConsole(bool b)
        {
            if(b)
            {
                ShowWindow(GetConsoleWindow(), 5);
                mIsHidden = true;
            }
            else
            {
                ShowWindow(GetConsoleWindow(), 0);
                SetForegroundWindow(GetConsoleWindow());
                mIsHidden = false;
            }
        }


        /// <summary>
        /// Catch exit event
        /// Realistically we have 4-5 seconds to preform this
        /// action before windows forces the program to close
        /// </summary>
        /// <param name="eventType">Event type</param>
        /// <returns>Retuurns bool</returns>
        static bool ConsoleEventCallback(int eventType)
        {
            /*eventType 2 being Exit event*/
            if (eventType == 2)
            {
                /*Disconnect all clients*/
                Console.WriteLine("\n\nDisconnecting...");
                foreach(var Bot in mSession.mActiveBots)
                {
                    /*Disconnect bot*/
                    Bot.mIsRunning = false;
                    Bot.mSteam.client.Disconnect();
                }
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
            /*Initialize application*/
            if (!Initialize())
                return;

            /*Set exit events*/
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);

            /*Initialize trayicon thread*/
            mThreadTray = new Thread(ToTray);
            mThreadTray.Start();

            /*Minimize app*/
            Console.WriteLine("\n\n  Hiding to tray in two...");
            Thread.Sleep(2000);
            ShowConsole(false);
            mTrayIcon.ShowBalloonTip(1000, "HourBoostr", "I'm down here!", ToolTipIcon.Info);

            /*Keep it alive*/
            while (true)
            {
                /*Take input commands*/
                Console.WriteLine(mCommand.GetCommand(Console.ReadLine()));
                Thread.Sleep(100);
            }
        }
    }
}
