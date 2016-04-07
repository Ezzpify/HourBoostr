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
        /// Application tray icon
        /// Used for hiding/showing the application in a click
        /// </summary>
        static private NotifyIcon mTrayIcon = new NotifyIcon();


        /// <summary>
        /// Thread variables
        /// </summary>
        static private Thread mThreadTray;


        /// <summary>
        /// Console event handler
        /// </summary>
        static private ConsoleEventDelegate handler;


        /// <summary>
        /// Application settings class
        /// </summary>
        static private Config.Settings mSettings;


        /// <summary>
        /// Our session
        /// </summary>
        static private Session mSession;


        /// <summary>
        /// Represents if the console is hidden
        /// </summary>
        static private bool mIsHidden;


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
                var tempacc = new Config.AccountInfo();
                tempacc.SetTemporaryValues();
                settings.Account.Add(tempacc);
                settings.Account.Add(tempacc);
                settings.Account.Add(tempacc);

                /*Write settings to file*/
                string settingsJson = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(filePath, settingsJson);
                Console.WriteLine("Settings.json has been written. Edit it for your accounts.");
                Thread.Sleep(1500);
            }
            else
            {
                /*Enable missing objects error*/
                JsonSerializerSettings jsonSettings = new JsonSerializerSettings();
                jsonSettings.MissingMemberHandling = MissingMemberHandling.Error;
                string settingsJson = string.Empty;

                try
                {
                    /*Load the settings from file*/
                    settingsJson = File.ReadAllText(filePath);
                    mSettings = JsonConvert.DeserializeObject<Config.Settings>(settingsJson, jsonSettings);

                    /*Write the class to settins file incase some of the settings were missing from the file originally*/
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(mSettings, Formatting.Indented));
                    return true;
                }
                catch (JsonReaderException ex)
                {
                    /*There was an error parsing the json file, most likely due to user trying to manually edit it without knowing the syntax*/
                    Console.WriteLine("Error: The settings file is corrupt. Please delete it and restart the program.");
                    Console.WriteLine($"{ex.Message}\n\n");
                }
                catch (Exception ex)
                {
                    /*I wonder what happened here?*/
                    Console.WriteLine("Error: An unhandled exception occured when parsing the settings? What the hell?");
                    Console.WriteLine($"{ex.Message}\n\n");
                }
            }

            Console.WriteLine("Exiting in 10 seconds...");
            Thread.Sleep(10000);
            return false;
        }


        /// <summary>
        /// Initializes our application
        /// </summary>
        /// <returns>Returns false if failed</returns>
        static private bool Initialize()
        {
            /*Create files and folders for our program*/
            Console.Title = "HourBoostr by Ezzpify";
            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Sentryfiles"));

            /*Spawn new userinfo settings incase null*/
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
            ShowConsole(!mIsHidden);
        }


        /// <summary>
        /// Show/Hide the console window
        /// </summary>
        /// <param name="b">Toggles console window</param>
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
        /// <returns>Returns bool</returns>
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
            if (mSettings.HideToTrayAutomatically)
            {
                Console.WriteLine("\n\n  Hiding to tray in two...");
                Thread.Sleep(2000);
                ShowConsole(false);
                mTrayIcon.ShowBalloonTip(1000, "HourBoostr", "I'm down here!", ToolTipIcon.Info);
            }

            /*Make a nice log stuff or whatever*/
            Console.WriteLine("\n\n  Log:\n  ----------------------------------------\n");

            /*Keep it alive*/
            while (true)
            {
                /*Take input commands*/
                Thread.Sleep(250);
            }
        }
    }
}
