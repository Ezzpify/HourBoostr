using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

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
                    Account = new List<Config.AccountSettings>()
                    {
                        new Config.AccountSettings() { Games = new List<int>() { 730, 10 } },
                        new Config.AccountSettings() { Games = new List<int>() { 730, 10 } },
                        new Config.AccountSettings() { Games = new List<int>() { 730, 10 } }
                    }
                };
                
                File.WriteAllText(EndPoint.SETTINGS_FILE_PATH, JsonConvert.SerializeObject(settings, Formatting.Indented));
                Console.WriteLine($"Settings file has been written at {EndPoint.SETTINGS_FILE_PATH}");
                Console.WriteLine("Please close the program and edit the settings.");
            }
            else
            {
                var serializeSettings = new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Error };
                try
                {
                    return JsonConvert.DeserializeObject<Config.Settings>(File.ReadAllText(EndPoint.SETTINGS_FILE_PATH));
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
        public static bool SaveSettings(Config.Settings oldSettings, Config.Settings newSettings)
        {
            try
            {
                /*We'll compare the settings file when we launched the program to the current settings object*/
                /*This way we'll see if the user has made any changes to the settings file during runtime*/
                /*We'll compare the two classes as serialized strings, mostly because I cba to implement an Equals solution*/
                var currentFile = JsonConvert.DeserializeObject<Config.Settings>(File.ReadAllText(EndPoint.SETTINGS_FILE_PATH));
                if (JsonConvert.SerializeObject(currentFile) != JsonConvert.SerializeObject(oldSettings))
                {
                    /*The settings file has been changed, so we'll make a copy of the one we have before overwriting it*/
                    /*We'll do this so any changes that the user might have made don't get lost in the twisting nether*/
                    string unixTimestamp = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
                    File.Copy(EndPoint.SETTINGS_FILE_PATH, Path.GetFileNameWithoutExtension(EndPoint.SETTINGS_FILE_PATH) + $" backup ({unixTimestamp}).json");
                }
                
                /*Now we'll go through all accounts and make sure we don't print out their password to the file
                if no password was originally set in the settings file*/
                foreach (var oldAcc in oldSettings.Account)
                {
                    if (!string.IsNullOrWhiteSpace(oldAcc.Password))
                        continue;

                    foreach (var newAcc in newSettings.Account)
                    {
                        if (oldAcc.Username == newAcc.Username)
                            newAcc.Password = string.Empty;
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
