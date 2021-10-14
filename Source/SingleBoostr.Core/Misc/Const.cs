using SingleBoostr.Core.Objects;

namespace SingleBoostr.Core.Misc
{
    public sealed class Const
    {
        public sealed class GitHub
        {
            public const string USER = "Ni1kko";
            public const string REPO = "HourBoostr";
            public const string BRANCH = "master";

            public static string PROFILE_URL = Utils.GITHUB_URL(false, $"{USER}/");
            public static string REPO_URL => $"{PROFILE_URL}/{REPO}/";
            public static string REPO_RELEASE_URL = $"{REPO_URL}releases/latest";
            public static string NEW_ISSUE_URL = $"{REPO_URL}issues/new";

            public static string GITHUB_PROFILE_URLRAW = Utils.GITHUB_URL(true, $"{USER}/");
            public static string GITHUB_REPO_URLRAW => $"{GITHUB_PROFILE_URLRAW + REPO}/";
            public static string VERSION_FILE_URL = $"{GITHUB_REPO_URLRAW + BRANCH}/version.json";
            public static string CHAT_BUBBLE_URL = $"{GITHUB_REPO_URLRAW + BRANCH}/Bubbles.json";
            public static string DONATION_URL = $"{GITHUB_REPO_URLRAW + BRANCH}/donation.json";
        }

        public sealed class Steam
        {
            public const string NAME = "Steam";
            public static string EXE => $"{NAME}.exe";
            public static SteamGroup GROUP = new SteamGroup(34411249, "Fallox");
            public const int MAX_GAMES = 33;
            public static string APP_LIST_URL =>   Utils.STEAM_URL("api", "ISteamApps/GetAppList/v2");
            public static string STORE_JSON_URL => Utils.STEAM_URL("store", "api/appdetails/?appids=");
            public static string CARD_PRICE_URL => Utils.STEAM_URL("enhancedsteam", "market_data/average_card_prices/?cur=eur&appids=");
        }

        public sealed class SingleBoostr
        {
            public const string NAME = "SingleBoostr";
            public static string IDLER_EXE => $"{NAME}.Game.exe";
            public static string APP_LIST => $"{NAME}.AppList.json";
            public static string SETTINGS_FILE => $"{NAME}.Settings.json";
        }

        public sealed class HourBoostr
        {
            public const string NAME = "HourBoostr";
            public static string IDLER_EXE => $"{NAME}.exe";
            public static string SETTINGS_EXE => $"{NAME}.Settings.exe";
            public static string SETTINGS_FILE => $"{NAME}.Settings.json";
        }

        public sealed class Discord
        {
            public const string NAME = "Discord";
            public static string EXE => $"{NAME}.exe";
            public static DiscordServer SERVER = new DiscordServer("W3qgHqNhax", "Fallox");
        }

        public const int INTERNET_COOKIE_HTTP_ONLY = 0x2000;
        public const int EM_SETCUEBANNER = 0x1501;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int SW_MAXIMIZE = 3;
        public const int SW_MINIMIZE = 6;
        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;
        public const int SB_HORZ = 0;
        public const int SB_VERT = 1;
        public const int SB_BOTH = 3;
    }
}
