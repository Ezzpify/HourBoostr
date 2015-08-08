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

namespace HourBoostr
{
    class Program
    {
        /// <summary>
        /// DllImports for hiding/showing window
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        /// <summary>
        /// Global variables
        /// </summary>
        static private List<BotClass> _ActiveBots = new List<BotClass>();
        static private DateTime       _InitializedTime;
        static private string         _Title = "HourBoostr by Ezzy";
        static private NotifyIcon     _TrayIcon = new NotifyIcon();
        static private bool           _IsHidden;


        /// <summary>
        /// Thread variables
        /// </summary>
        static private Thread _StatusThread;
        static private Thread _TrayThread;


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

            /*Check if Json settings file exist*/
            if(!File.Exists(_filePath))
            {
                /*Construct new classes to print an example settings file*/
                MessageBox.Show("Writing a new Settings.json\nGo and edit it!", "Wizard");
                Config.SettingsInfo SettingsInfo = new Config.SettingsInfo()
                {
                    Username = "",
                    Games = new List<int> { 730 }
                };
                Config.Settings Settings = new Config.Settings()
                {
                    /*Print two json entries as an example*/
                    Account = new List<Config.SettingsInfo> { SettingsInfo, SettingsInfo }
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
                JObject Settings = JObject.Parse(File.ReadAllText(_filePath));

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
                    if(User.Username.Length > 0 && User.Games != null)
                    {
                        /*Let user type in password to account*/
                        Console.WriteLine("Enter the password for the account '{0}'.", User.Username);
                        User.Password = Config.Password.ReadPassword();

                        /*Run a new bot with the information*/
                        BotClass Bot = new BotClass(User);

                        /*Add bot to active list*/
                        _ActiveBots.Add(Bot);

                        /*Wait for bot to log in fully until we initialize the next account*/
                        while (!Bot._IsLoggedIn) { Thread.Sleep(2500); }
                    }
                    else
                    {
                        /*Some information is missing, throw and error and exit app*/
                        Console.WriteLine(String.Format("Account #{0} has invalid/missing information - skipping", (Account.i + 1)));
                    }
                }

                /*Done loading all bots*/
                Console.Clear();
                Console.WriteLine("\n  _____             _               _       ");
                Console.WriteLine(" |  |  |___ _ _ ___| |_ ___ ___ ___| |_ ___ ");
                Console.WriteLine(" |     | . | | |  _| . | . | . |_ -|  _|  _|");
                Console.WriteLine(" |__|__|___|___|_| |___|___|___|___|_| |_|  \n");
                Console.WriteLine("\n  Loaded {0} bots!", _ActiveBots.Count);
                Console.WriteLine("\n  Accounts:\n");
                foreach(var Bot in _ActiveBots)
                {
                    Console.WriteLine("    {0} | {1} Games", Bot._Username, Bot._Games.Count);
                }
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
                TimeSpan span = DateTime.Now.Subtract(_InitializedTime);
                Console.Title = String.Format("{0} | Online for: {1} Hours", _Title, span.Hours);
                Thread.Sleep(1000);
            }
        }


        /// <summary>
        /// HACK HACK!
        /// Initialize the tray icon thread
        /// Keep it running
        /// </summary>
        static private void ToTray()
        {
            _TrayIcon.Text = String.Format("HourBoostr | {0} Bots", _ActiveBots.Count);
            _TrayIcon.Icon = Properties.Resources.icon;
            _TrayIcon.Click += new EventHandler(_TrayIcon_Click);
            _TrayIcon.Visible = true;
            Application.Run();

            while (true) { Thread.Sleep(100); }
        }


        /// <summary>
        /// TrayIcon click event
        /// Show/Hide the window depending on its' state
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
        /// <param name="b"></param>
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
                _IsHidden = false;
            }
        }


        /// <summary>
        /// Main function
        /// Too many comments
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
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
                Console.WriteLine("  Hiding console to Tray in 3s...\n\n");
                Thread.Sleep(3000);
                ShowConsole(false);
                _TrayIcon.ShowBalloonTip(1000, "HourBoostr", "I'm still running! Click me to show/hide the window.", ToolTipIcon.Info);
            }
            else
            {
                /*No accounts loaded... Killed the bot*/
                Console.WriteLine("  No accounts loaded. Exiting in 2s...");
                Thread.Sleep(2000);
                Environment.Exit(1);
            }

            /*Keep it alive*/
            while(true)
            {
                Thread.Sleep(100);
            }
        }
    }
}
