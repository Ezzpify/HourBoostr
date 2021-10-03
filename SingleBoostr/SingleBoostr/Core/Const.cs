using System.Drawing;

namespace SingleBoostr.Core
{
    internal class Const
    {
        internal const string GAME_EXE = "SingleBoostr.Game.exe";
        internal const string APP_LIST = "AppList.json";
        internal const string SETTINGS_FILE = "Settings.json";
        internal const string GITHUB_PROFILE_URL = "https://github.com/Ezzpify/";
        internal const string GITHUB_REPO_URL = "https://github.com/Ezzpify/HourBoostr/";
        internal const string STEAM_GROUP_URL = "http://steamcommunity.com/gid/103582791455389825";
        internal const string APP_LIST_URL = "http://api.steampowered.com/ISteamApps/GetAppList/v2";
        internal const string STORE_JSON_URL = "http://store.steampowered.com/api/appdetails/?appids=";
        internal static string REPO_RELEASE_URL = "https://github.com/Ezzpify/HourBoostr/releases/latest";
        internal static string VERSION_FILE_URL = "https://raw.githubusercontent.com/Ezzpify/HourBoostr/master/version.json";
        internal const string CARD_PRICE_URL = "https://api.enhancedsteam.com/market_data/average_card_prices/?cur=eur&appids=";
        internal const string CHAT_BUBBLE_URL = "https://raw.githubusercontent.com/Ezzpify/HourBoostr/master/Bubbles.json";
        internal const string DONATION_URL = "https://raw.githubusercontent.com/Ezzpify/HourBoostr/master/donation.json";

        internal const int INTERNET_COOKIE_HTTP_ONLY = 0x2000;
        internal const int EM_SETCUEBANNER = 0x1501;
        internal const int WM_NCLBUTTONDOWN = 0xA1;
        internal const int HT_CAPTION = 0x2;
        internal const int MAX_GAMES = 33;
        internal const int SW_MAXIMIZE = 3;
        internal const int SW_MINIMIZE = 6;
        internal const int SW_HIDE = 0;
        internal const int SW_SHOW = 5;
        internal const int SB_HORZ = 0;
        internal const int SB_VERT = 1;
        internal const int SB_BOTH = 3;

        internal static Color LABEL_HOVER = Color.FromArgb(255, 73, 131);
        internal static Color LABEL_NORMAL = Color.Gray;
    }
}
