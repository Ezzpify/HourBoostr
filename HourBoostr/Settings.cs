using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Linq;

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
            if (!File.Exists(EndPoint.SETTINGS_FILE_PATH))
            {
                var settings = new Config.Settings()
                {
                    Accounts = new List<Config.AccountSettings>()
                    {
                        new Config.AccountSettings() { Games = new List<int>() { 730, 10 } },
                        new Config.AccountSettings() { Games = new List<int>() { 730, 10 } },
                        new Config.AccountSettings() { Games = new List<int>() { 730, 10 } }
                    }
                };
                
                File.WriteAllText(EndPoint.SETTINGS_FILE_PATH, JsonConvert.SerializeObject(settings, Formatting.Indented));
                Console.WriteLine($"Settings file has been written at {EndPoint.SETTINGS_FILE_PATH}\nPlease close the program and edit the settings.");
            }
            else
            {
                var serializeSettings = new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Error };
                try
                {
                    var settings = JsonConvert.DeserializeObject<Config.Settings>(File.ReadAllText(EndPoint.SETTINGS_FILE_PATH));
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
        /// Saves the settings that has been modified during runtime
        /// Should be called when the program is exited
        /// It will first compare and see if the current file is the same as when the program was started
        /// If it's not then it will make a copy of the file and then overwrite it, if the user has modified
        /// the file during runtime
        /// </summary>
        /// <param name="oldSettings">Old settings</param>
        /// <param name="newSettings">New settings</param>
        /// <returns>Returns true if succeeded</returns>
        public static bool UpdateSettings(Config.Settings oldSettings, Config.Settings newSettings)
        {
            try
            {
                /*Now we'll go through all accounts and make sure we don't print out their password to the file
                if no password was originally set in the settings file*/
                foreach (var oldAcc in oldSettings.Accounts)
                {
                    if (!string.IsNullOrWhiteSpace(oldAcc.Details.Password))
                        continue;

                    foreach (var newAcc in newSettings.Accounts)
                    {
                        if (oldAcc.Details.Username == newAcc.Details.Username)
                            newAcc.Details.Password = string.Empty;
                    }
                }

                /*Now we'll overwrite the settings file with the new settings content*/
                File.WriteAllText(EndPoint.SETTINGS_FILE_PATH, JsonConvert.SerializeObject(newSettings, Formatting.Indented));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating settings file\n{ex.Message}");
            }

            return false;
        }
    }
}
