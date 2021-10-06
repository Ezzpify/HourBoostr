using System; 
using SingleBoostr.Core.Objects;
using System.Threading;
using System.Threading.Tasks;
using Nito.AsyncEx;
using System.Linq;

namespace SingleBoostr.Game
{
    public class Program
    {
        private static Core.Objects.Steam Base;
        private static uint AppID = 0;
        private static SteamApp APP => Base.APPS.Where(a => a.ID == AppID).ToList()[0];
        private static Thread DynamicTextThread { get; set; } = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            double playtime = 0;
            while (true)
            {
                Console.Title = $"Idling \"{APP.Title}\" [{APP.ID}] | Uptime: {APP.UpTime}";

                if(playtime != APP.Playtime)
                {
                    playtime = APP.Playtime;
                    Console.WriteLine($"Total hours on record: {APP.Playtime}");
                }
                Thread.Sleep(1 * 900);
            }
        });

        public static void Main(string[] args) => AsyncContext.Run(() => MainAsync(args.Length > 0 ? args[0] : ""));

        public static async Task MainAsync(string appID)
        {
            string ApiKey = "";
            AppID = await ParseAppID(appID);
            
            Base = new Core.Objects.Steam(ApiKey, AppID);
             
            if (await Base.Connect())
            {
                DynamicTextThread.Start();

                //wait
                Console.WriteLine("Running! Press any key or close window to stop idling.");
                Console.ReadKey();

                //close 
                await Base.Disconnect();
                DynamicTextThread.Abort();
            }
        }

        public static async Task<uint> ParseAppID(string appID)
        {
            uint AppID;
            if (string.IsNullOrEmpty(appID))
            {
                do Console.WriteLine("Enter appId of game you wish to boost:");
                while (!uint.TryParse(Console.ReadLine().Trim(), out AppID));
                await Task.Delay(1 * 1000);
                Console.Clear();
            }
            else
            {
                if (!uint.TryParse(appID, out AppID))
                {
                    Console.WriteLine($"ERROR: Unable to parse '{appID}' as an app id.\n\nPress any key to exit...");
                    Console.ReadKey();
                    return 0;
                }
            }
            return AppID;
        }
    }
}
