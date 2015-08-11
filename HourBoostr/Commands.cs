using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourBoostr
{
    class Commands
    {
        /// <summary>
        /// List of available commands
        /// </summary>
        public List<string> _Commands = new List<string>()
        {
            "!reset - Resets saved passwords"
        };


        /// <summary>
        /// Handles input commands
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetCommand(string str)
        {
            switch(str)
            {
                case "!420":
                    return "Blaze it";
                case "!reset":
                    Properties.Settings.Default.UserInfo.Clear();
                    Properties.Settings.Default.Save();
                    return "";
                default:
                    return "";
            }
        }
    }
}
