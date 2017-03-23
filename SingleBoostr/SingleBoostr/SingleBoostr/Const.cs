using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SingleBoostr
{
    class Const
    {
        public const string GAME_EXE = "SingleBoostr.Game.exe";
        public const string APP_LIST = "AppList.json";
        public const string SETTINGS_FILE = "Settings.json";
        public const string GITHUB_PROFILE_URL = "https://github.com/Ezzpify/";
        public const string GITHUB_REPO_URL = "https://github.com/Ezzpify/HourBoostr/";
        public const string STEAM_GROUP_URL = "http://steamcommunity.com/gid/103582791455389825";
        public const string APP_LIST_URL = "http://api.steampowered.com/ISteamApps/GetAppList/v2";
        public const string STORE_JSON_URL = "http://store.steampowered.com/api/appdetails/?appids=";
        public static string REPO_RELEASE_URL = "https://github.com/Ezzpify/HourBoostr/releases/latest";
        public static string VERSION_FILE_URL = "https://raw.githubusercontent.com/Ezzpify/HourBoostr/master/version.txt";
        public const string CARD_PRICE_URL = "https://api.enhancedsteam.com/market_data/average_card_prices/?cur=eur&appids=";

        public const int INTERNET_COOKIE_HTTP_ONLY = 0x2000;
        public const int EM_SETCUEBANNER = 0x1501;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int MAX_GAMES = 33;

        public static Color LABEL_HOVER = Color.FromArgb(255, 73, 131);
        public static Color LABEL_NORMAL = Color.Gray;
    }
}
