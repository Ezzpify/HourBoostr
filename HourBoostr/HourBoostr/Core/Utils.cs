﻿using System.Reflection;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HourBoostr
{
    internal class Utils
    {
        public static string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.ProductVersion;
        }

        /// <summary>
        /// Masked password input
        /// </summary>
        /// <param name="mask">Mask char</param>
        /// <returns>Returns string</returns>
        public static string ReadPassword(char mask)
        {
            const int ENTER = 13, BACKSP = 8, CTRLBACKSP = 127;
            int[] FILTERED = { 0, 27, 9, 10 /*, 32 space, if you care */ };

            var pass = new Stack<char>();
            char chr = (char)0;

            while ((chr = Console.ReadKey(true).KeyChar) != ENTER)
            {
                if (chr == BACKSP)
                {
                    if (pass.Count > 0)
                    {
                        Console.Write("\b \b");
                        pass.Pop();
                    }
                }
                else if (chr == CTRLBACKSP)
                {
                    while (pass.Count > 0)
                    {
                        Console.Write("\b \b");
                        pass.Pop();
                    }
                }
                else
                {
                    if (FILTERED.Count(x => chr == x) == 0)
                    {
                        pass.Push(chr);
                        Console.Write(mask);
                    }
                }
            }

            Console.WriteLine();
            return new string(pass.Reverse().ToArray());
        }
    }
}
