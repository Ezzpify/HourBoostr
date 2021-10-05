using System.IO;

namespace HourBoostr
{
    class EndPoint
    {
        public static string SETTINGS_FILE_PATH = "Settings.json";
        public static string GLOBAL_SETTINGS_FILE_PATH = "GlobalDB.hb";
        public static string SENTRY_FOLDER_PATH = "Sentryfiles";
        public static string LOG_FOLDER_PATH = "Logs";
        public static string CONSOLE_TITLE = $"HourBoostr v{Utils.GetVersion()}";
        public static string STEAM_GROUP_URL = "http://steamcommunity.com/gid/103582791455389825";
        public static string VERSION_FILE = "https://raw.githubusercontent.com/Ezzpify/HourBoostr/master/version.txt";
    }
}