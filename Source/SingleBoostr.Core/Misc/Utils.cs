using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace SingleBoostr.Core.Misc
{
    public class Utils
    {
        private static Random _random = new Random();

        public static Random GetRandom()
        {
            return _random;
        }

        public static string GetTimestamp()
        {
            return DateTime.Now.ToString("d/M/yyyy HH:mm:ss");
        }

        public static string GetMachineGuid()
        {
            using RegistryKey localMachineX64View = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            using RegistryKey rk = localMachineX64View.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography");
            if (rk == null) throw new KeyNotFoundException(@"Key Not Found: SOFTWARE\Microsoft\Cryptography");
            object machineGuid = rk.GetValue("MachineGuid");
            if (machineGuid == null) throw new IndexOutOfRangeException("Index Not Found: MachineGuid");
            return machineGuid.ToString();
        }

        public static bool IsOnlyNumbers(string str)
        {
            return new Regex("^[0-9]+$").IsMatch(str);
        }

        public static string GetUnicodeString(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
        }

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
