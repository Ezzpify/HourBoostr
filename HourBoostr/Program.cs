using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

namespace HourBoostr
{
    class Program
    {
        /// <summary>
        /// DllImports
        /// </summary>
        /// <returns></returns>[DllImport("user32.dll")]
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);


        /// <summary>
        /// Global variables
        /// </summary>
        static private List<BotClass> _ActiveBots = new List<BotClass>();
        static private DateTime       _InitializedTime;
        static private string         _Title = "HourBoostr by Ezzy";
        static private NotifyIcon     _TrayIcon = new NotifyIcon();
        static private bool           _IsHidden;
        static private Commands       _Com = new Commands();


        /// <summary>
        /// Thread variables
        /// </summary>
        static private Thread _StatusThread;
        static private Thread _TrayThread;


        /// <summary>
        /// Fetch a user password if it exists in settings
        /// </summary>
        /// <param name="Username">Username of the account we wish to get creds to</param>
        /// <returns></returns>
        static private string GetUserInfo(string Username)
        {
            /*Load up saved creds to an array*/
            string[] strArr = Properties.Settings.Default.UserInfo.Cast<string>().ToArray();

            /*Apply LINQ to get the first result that matches the Username*/
            if (strArr.Length != 0) { return strArr.First(s => s.Contains(Username)); }
            else { return ""; }
        }


        /// <summary>
        /// Initialize the program
        /// Load settings file and load each individual bot
        /// </summary>
        static private void Initialize()
        {
            /*Create files and folders for our program*/
            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "Sentryfiles"));
            string _filePath = Path.Combine(Application.StartupPath, "Settings.json");
            Console.Title = _Title;

            /*Spawn new settings*/
            if (Properties.Settings.Default.UserInfo == null)
                Properties.Settings.Default.UserInfo = new StringCollection();

            /*Check if Json Settings file exist, else print a new one*/
            if(!File.Exists(_filePath))
            {
                /*Construct new classes to print an example settings file*/
                MessageBox.Show("Writing a new Settings.json\nGo and edit it!", "Wizard");
                Config.SettingsInfo SettingsInfo = new Config.SettingsInfo()
                {
                    Username = "",
                    Games = new List<int> { 730, 10 }
                };
                Config.Settings Settings = new Config.Settings()
                {
                    /*Print three json entries as an example*/
                    Account = new List<Config.SettingsInfo> { SettingsInfo, SettingsInfo, SettingsInfo }
                };

                /*Write the serialized class to file*/
                String _settingsString = JsonConvert.SerializeObject(Settings, Formatting.Indented);
                File.WriteAllText(_filePath, _settingsString);

                /*Open folder containing settings file and exit*/
                string argument = @"/select, " + _filePath;
                Process.Start("explorer.exe", argument);
                Environment.Exit(1);
            }
            else
            {
                /*Parse the Settings.json file*/
                JObject Settings = null;
                try 
                {
                    /*Try to parse the file*/
                    Settings = JObject.Parse(File.ReadAllText(_filePath)); 
                }
                catch (JsonException jEx) 
                {
                    /*Error parsing the file. User messed up the syntax*/
                    MessageBox.Show(
                        "There was an error parsing Settings.json\n"
                        + "You probably set it up incorrectly.\n\n"
                        + "You can delete the Settings.json and run the program again\n"
                        + "and it will spawn a new example file.\n\n"
                        + "Error message:\n"
                        + jEx.Message, "Json error");

                    /*Exit*/
                    Environment.Exit(1);
                }

                /*Fool check if Settings isn't null*/
                if(Settings == null)
                {
                    /*Don't know how this would normally proc, but never underestimate users*/
                    MessageBox.Show("Settings is null.\nExiting.", "Oops.");
                    Environment.Exit(1);
                }

                /*Loop through all accounts set*/
                foreach(var Account in Settings["Account"].Select((value,i) => new {i, value}))
                {
                    /*Add all requested games to list*/
                    List<int> _Games = new List<int>();
                    foreach(var Game in Account.value["Games"])
                    {
                        _Games.Add((int)Game);
                    }

                    /*Construct a new account class*/
                    Config.AccountInfo User = new Config.AccountInfo()
                    {
                        Username = (string)Account.value["Username"],
                        Games = _Games
                    };

                    /*If not empty*/
                    if(User.Username.Length > 0)
                    {
                        /*Check if we have a saved password*/
                        bool AutoLogin = false;

                        /*Retrieve cred string and split (cred format: Username,Password)*/
                        string savedCreds = GetUserInfo(User.Username);
                        if(!string.IsNullOrEmpty(savedCreds))
                        {
                            User.Password = savedCreds.Split(',')[1];
                        }

                        /*Check if we have a password set*/
                        if(string.IsNullOrEmpty(User.Password))
                        {
                            /*Password was not saved, promt user to enter password for account*/
                            Console.WriteLine("Enter the password for the account '{0}'.", User.Username);
                            User.Password = Config.Password.ReadPassword();
                        }
                        else
                        {
                            /*Saved password was found, log in*/
                            Console.WriteLine("Logging in '{0}'...", User.Username);
                            AutoLogin = true;
                        }

                        /*Run a new bot with the information*/
                        BotClass Bot = new BotClass(User, AutoLogin);

                        /*Add bot to active bot list*/
                        _ActiveBots.Add(Bot);

                        /*Wait for bot to log in fully until we initialize the next account*/
                        while (!Bot._IsLoggedIn) { Thread.Sleep(1500); }
                    }
                }

                /*Done loading all bots*/
                /*Print some ascii stuff and information about bots*/
                Console.Clear();
                Console.WriteLine("\n  _____             _               _       ");
                Console.WriteLine(" |  |  |___ _ _ ___| |_ ___ ___ ___| |_ ___ ");
                Console.WriteLine(" |     | . | | |  _| . | . | . |_ -|  _|  _|");
                Console.WriteLine(" |__|__|___|___|_| |___|___|___|___|_| |_|  \n");
                Console.WriteLine("\n  Loaded {0} bots!", _ActiveBots.Count);
                Console.WriteLine("\n  Accounts:\n");

                /*Count games for each bot*/
                foreach(var Bot in _ActiveBots)
                {
                    Console.WriteLine("    {0} | {1} Games", Bot._Username, Bot._Games.Count);
                }

                /*Print available commands*/
                Console.WriteLine("\n  Commands available:");
                foreach(string command in _Com._Commands)
                {
                    Console.WriteLine("  {0}", command);
                }

                /*Divider to make it look nicer*/
                Console.WriteLine("\n  ------------------------------------------\n");

                /*Set time when bots were initialized*/
                _InitializedTime = DateTime.Now;
            }
        }


        /// <summary>
        /// Status for how long the bot has been running
        /// </summary>
        static private void CheckStatus()
        {
            while(true)
            {
                /*Get the current time then subtract the time when all bots were done initializing*/
                /*This will give us an idea of how long the bot has been running*/
                TimeSpan span = DateTime.Now.Subtract(_InitializedTime);
                Console.Title = String.Format("{0} | Online for: {1} Hours", _Title, span.Hours);
                Thread.Sleep(30000);
            }
        }


        /// <summary>
        /// HACK HACK!
        /// Initialize the tray icon thread
        /// Keep it running
        /// </summary>
        static private void ToTray()
        {
            /*Set TrayIcon information*/
            _TrayIcon.Text = String.Format("HourBoostr | {0} Bots\nClick to Show/Hide", _ActiveBots.Count);
            _TrayIcon.Icon = Properties.Resources.icon;
            _TrayIcon.Click += new EventHandler(_TrayIcon_Click);
            _TrayIcon.Visible = true;
            Application.Run();

            /*To keep TrayIcon from dropping (dissapearing), 
              we need to keep the thread running*/
            while (true) { Thread.Sleep(250); }
        }


        /// <summary>
        /// TrayIcon click event
        /// Show/Hide the window depending on its state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static private void _TrayIcon_Click(object sender, EventArgs e)
        {
            ShowConsole(!_IsHidden);
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
                _IsHidden = true;
            }
            else
            {
                ShowWindow(GetConsoleWindow(), 0);
                SetForegroundWindow(GetConsoleWindow());
                _IsHidden = false;
            }
        }


        /// <summary>
        /// Catch exit event
        /// Realistically we have 4-5 seconds to preform this
        /// action before windows forces the program to close
        /// </summary>
        /// <param name="eventType">Event type</param>
        /// <returns></returns>
        static bool ConsoleEventCallback(int eventType)
        {
            /*eventType 2 being Exit event*/
            if (eventType == 2)
            {
                /*Disconnect all clients*/
                Console.WriteLine("\n\nDisconnecting...");
                foreach(var Bot in _ActiveBots)
                {
                    /*Disconnect bot*/
                    Bot._IsRunning = false;
                    Bot._SteamClient.Disconnect();
                }
            }

            return false;
        }
        static ConsoleEventDelegate handler;


        /// <summary>
        /// Main function
        /// Too many comments
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /*Debugging*/
            if (Debugger.IsAttached)
                Properties.Settings.Default.Reset();

            /*Initialize the program*/
            Initialize();

            /*Initialize status thread*/
            _StatusThread = new Thread(CheckStatus);
            _StatusThread.Start();

            /*Initialize trayicon thread*/
            _TrayThread = new Thread(ToTray);
            _TrayThread.Start();

            /*Hide console*/
            if (_ActiveBots.Count > 0)
            {
                /*Hide the program to Tray*/
                Console.WriteLine("  Hiding console to Tray in 3s...\n\n");
                Thread.Sleep(3000);
                ShowConsole(false);
                _TrayIcon.ShowBalloonTip(1500, "HourBoostr", "I'm still running! Click me to show/hide the window.", ToolTipIcon.Info);
            }
            else
            {
                /*No accounts loaded... Killed the bot*/
                Console.WriteLine("  No accounts loaded. Exiting in 2s...");
                Thread.Sleep(2000);
                Environment.Exit(1);
            }

            /*Set exit events*/
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);

            /*Keep it alive*/
            while(true)
            {
                /*Take input commands*/
                Console.WriteLine(_Com.GetCommand(Console.ReadLine()));
                Thread.Sleep(100);
            }
        }
    }
}
