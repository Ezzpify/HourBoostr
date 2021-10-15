﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace SingleBoostr.Core.Misc
{
    public static class Utils
    {
        private static readonly Random _random = new Random();
        public static Random GetRandom() => _random;
        public static string GetTimestamp() => DateTime.Now.ToString("d/M/yyyy HH:mm:ss");
        public static bool IsOnlyNumbers(string str) => new Regex("^[0-9]+$").IsMatch(str);
        public static string GetUnicodeString(string str) => Encoding.UTF8.GetString(Encoding.Default.GetBytes(str)); 
        public static int LastModifed(this string file) => File.Exists(file) ? (int)(DateTime.Now - File.GetLastWriteTime(file)).TotalDays : -1;
        public static string Truncate(string value, int maxLength) => string.IsNullOrEmpty(value) ? value : value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
        public static string STEAM_URL(string sub, string request) => (sub.ToLower().Equals("community") ? "http://steamcommunity.com/" : sub.ToLower().Equals("enhancedsteam") ? "https://api.enhancedsteam.com/" : $"http://{sub.ToLower()}.steampowered.com/") + request;
        public static string GITHUB_URL(bool raw, string request) => (raw ? "https://raw.githubusercontent.com/" : "https://github.com/") + request;

        /// <summary>
        /// Handles custom variable replacment
        /// </summary>
        /// <param name="str">String to replace variables</param>
        /// <param name="steam">Steam Object Instance</param>
        /// <returns>String</returns>
        public static string ReplacementCallack(this string str, Objects.Steam steam)
        {
            string replacementCallack(Match match)
            {
                string r = "";

                switch (match.Groups[1].Value)
                {
                    case "PROJECT_ONE_NAME":
                        r = Const.SingleBoostr.NAME;
                        break;
                    case "PROJECT_TWO_NAME":
                        r = Const.HourBoostr.NAME;
                        break;
                    case "PROJECT_ISSUE_URL":
                        r = Const.GitHub.NEW_ISSUE_URL;
                        break;
                    case "STEAM_ID":
                        r = steam.Steam64ID.ToString();
                        break;
                    case "STEAM_USER":
                        r = steam.DisplayName;
                        break;
                    case "DISCORD_SERVER_INVITE_URL":
                        r = Const.Discord.SERVER.InviteURL;
                        break;
                    case "DISCORD_SERVER_INVITE_CODE":
                        r = Const.Discord.SERVER.InviteCode;
                        break;
                    case "STEAM_GROUP_URL":
                        r = Const.Steam.GROUP.URL;
                        break;
                    case "STEAM_GROUP_ID":
                        r = Const.Steam.GROUP.ID.ToString();
                        break;
                    case "TIMESTAMP":
                        r = GetTimestamp();
                        break;
                }

                return r;
            }

            return Regex.Replace(str, @"\{([A-Z_]+)\}", replacementCallack);
        }

        /// <summary>
        /// Returns current HardwareID
        /// </summary>
        /// <returns>HardwareID</returns>
        public static string GetMachineGuid()
        {
            using RegistryKey localMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            using RegistryKey rk = localMachineX64View.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography");
            if (rk == null) throw new KeyNotFoundException(@"Key Not Found: SOFTWARE\Microsoft\Cryptography");
            object machineGuid = rk.GetValue("MachineGuid");
            if (machineGuid == null) throw new IndexOutOfRangeException("Index Not Found: MachineGuid");
            return machineGuid.ToString();
        }

        /// <summary>
        /// Checks if application is installed name
        /// </summary>
        /// <param name="p_name">application name</param>
        /// <returns>true/false</returns>
        public static bool IsApplicationInstalled(string p_name)
        {
            string displayName;
            RegistryKey key;

            try
            {
                // search in: CurrentUser
                key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return true;
                    }
                }

                // search in: LocalMachine_32
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return true;
                    }
                }

                // search in: LocalMachine_64
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (String keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    displayName = subkey.GetValue("DisplayName") as string;
                    if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        return true;
                    }
                }
            }
            catch
            {

            }

            // NOT FOUND
            return false;
        }
    }
}
