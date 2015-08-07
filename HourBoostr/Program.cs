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

namespace HourBoostr
{
    class Program
    {
        /// <summary>
        /// Global variables
        /// </summary>
        static private List<BotClass> _ActiveBots = new List<BotClass>();
        static private Thread _StatusThread;
        static private DateTime _InitializedTime;
        static private string _Title = "HourBoostr by Ezzy";


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
                        Console.WriteLine("Type the password for the account '{0}'.", User.Username);
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
                Console.WriteLine("\nLoaded '{0}' bots!", _ActiveBots.Count);
                Console.WriteLine("\nAccounts:");
                foreach(var Bot in _ActiveBots)
                {
                    Console.WriteLine("  {0}", Bot._Username);
                }
                Console.WriteLine("\n-------------------------------------------------\n");

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

            /*Keep it alive*/
            while(true)
            {
                Thread.Sleep(100);
            }
        }
    }
}
