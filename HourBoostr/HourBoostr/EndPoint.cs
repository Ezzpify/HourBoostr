using System.Windows.Forms;
using System.IO;

namespace HourBoostr
{
    class EndPoint
    {
        public static string SETTINGS_FILE_PATH = Path.Combine(Application.StartupPath, "Settings.json");
        public static string GLOBAL_SETTINGS_FILE_PATH = Path.Combine(Application.StartupPath, "GlobalDB.hb");
        public static string SENTRY_FOLDER_PATH = Path.Combine(Application.StartupPath, "Sentryfiles");
        public static string LOG_FOLDER_PATH = Path.Combine(Application.StartupPath, "Logs");
        public static string CONSOLE_TITLE = $"HourBoostr v{Application.ProductVersion}";
        public static string STEAM_GROUP_URL = "http://steamcommunity.com/gid/103582791455389825";
        public static string VERSION_FILE = "https://raw.githubusercontent.com/Ezzpify/HourBoostr/master/version.txt";
    }
}