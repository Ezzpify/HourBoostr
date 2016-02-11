using System.Collections.Generic;

namespace HourBoostr
{
    static class Commands
    {
        /// <summary>
        /// List of available commands
        /// </summary>
        public static List<string> mCommands = new List<string>()
        {
            "!reset - Resets saved passwords"
        };


        /// <summary>
        /// Handles input commands
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetCommand(string str)
        {
            switch(str)
            {
                case "!reset":
                    Properties.Settings.Default.UserInfo.Clear();
                    Properties.Settings.Default.Save();
                    return "Settings has been reset";
                default:
                    return "Command not found";
            }
        }
    }
}
