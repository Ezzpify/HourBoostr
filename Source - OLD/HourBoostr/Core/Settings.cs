﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Linq;
using HourBoostr.Objects;

namespace HourBoostr
{
    static class Settings
    {
        /// <summary>
        /// Read the settings for the application
        /// </summary>
        /// <returns></returns>
        public static Config.Settings GetSettings()
        {
            if (!File.Exists(SingleBoostr.Core.Misc.Const.HourBoostr.SETTINGS_FILE))
            {
                static SingleBoostr.Core.Objects.AccountSettings NewAccount() => new SingleBoostr.Core.Objects.AccountSettings() { Games = new List<int>() { 730, 10 } };

                var settings = new Config.Settings()
                {
                    Accounts = new List<SingleBoostr.Core.Objects.AccountSettings>()
                    {
                        NewAccount(),
                        NewAccount(),
                        NewAccount()
                    }
                };

                File.WriteAllText(SingleBoostr.Core.Misc.Const.HourBoostr.SETTINGS_FILE, JsonConvert.SerializeObject(settings, Formatting.Indented));
                Console.WriteLine($"Settings file has been written at {SingleBoostr.Core.Misc.Const.HourBoostr.SETTINGS_FILE}\nPlease close the program and edit the settings.");
            }
            else
            {
                var serializeSettings = new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Error };
                try
                {
                    var settings = JsonConvert.DeserializeObject<Config.Settings>(File.ReadAllText(SingleBoostr.Core.Misc.Const.HourBoostr.SETTINGS_FILE));
                    settings.Accounts = settings.Accounts.Where(o => !string.IsNullOrWhiteSpace(o.Details.Username)).Distinct().ToList();

                    return settings;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading settings file\n{ex.Message}");
                }
            }

            Thread.Sleep(1500);
            return null;
        }


        /// <summary>
        /// Writes settings to file
        /// </summary>
        /// <param name="settings">Settings object</param>
        /// <returns>Return true. Lol.</returns>
        public static bool SaveSettings(Config.Settings settings)
        {
            File.WriteAllText(SingleBoostr.Core.Misc.Const.HourBoostr.SETTINGS_FILE, JsonConvert.SerializeObject(settings, Formatting.Indented));
            return true;
        }

        public static void UpdateAccount(SingleBoostr.Core.Objects.AccountSettings acc)
        {
            var settings = GetSettings();
            settings.Accounts.First(o => o.Details.Username == acc.Details.Username).Details.LoginKey = acc.Details.LoginKey;
            File.WriteAllText(SingleBoostr.Core.Misc.Const.HourBoostr.SETTINGS_FILE, JsonConvert.SerializeObject(settings, Formatting.Indented));

            //var account = GetSettings().Accounts.First(o => o.Details.Username == acc.Details.Username);
            //account = acc;
            //File.WriteAllText(EndPoint.SETTINGS_FILE_PATH, JsonConvert.SerializeObject(settings, Formatting.Indented));
        }
    }
}