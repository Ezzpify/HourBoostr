using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourBoostr
{
    public class Config
    {
        /// <summary>
        /// Class for accounts
        /// </summary>
        public class Settings
        {
            public List<SettingsInfo> Account { get; set; }
        }


        /// <summary>
        /// Class for account info
        /// </summary>
        public class SettingsInfo
        {
            public string Username { get; set; }
            public List<int> Games { get; set; }
        }


        /// <summary>
        /// Class for account information
        /// </summary>
        public class AccountInfo
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public List<int> Games { get; set; }
        }


        /// <summary>
        /// Class for managing passwords
        /// </summary>
        public class Password
        {
            /// <summary>
            /// Masked password input
            /// </summary>
            /// <param name="mask"></param>
            /// <returns></returns>
            public static string ReadPassword(char mask)
            {
                const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
                int[] FILTERED = { 0, 27, 9, 10 /*, 32 space, if you care */ }; // const

                var pass = new Stack<char>();
                char chr = (char)0;

                while ((chr = System.Console.ReadKey(true).KeyChar) != ENTER)
                {
                    if (chr == BACKSP)
                    {
                        if (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                        }
                    }
                    else if (chr == CTRLBACKSP)
                    {
                        while (pass.Count > 0)
                        {
                            System.Console.Write("\b \b");
                            pass.Pop();
                        }
                    }
                    else if (FILTERED.Count(x => chr == x) > 0) { }
                    else
                    {
                        pass.Push((char)chr);
                        System.Console.Write(mask);
                    }
                }

                System.Console.WriteLine();

                return new string(pass.Reverse().ToArray());
            }

            /// <summary>
            /// Like System.Console.ReadLine(), only with a mask.
            /// </summary>
            /// <returns>the string the user typed in </returns>
            public static string ReadPassword()
            {
                return Password.ReadPassword('*');
            }
        }
    }
}
