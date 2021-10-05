using System; 
using SingleBoostr.Core.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace SingleBoostr.Game
{
    public class Program
    {
        private static Core.Objects.Steam Base;
        private static Thread DynamicTextThread { get; set; } = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            double playtime = 0;
            while (true)
            {
                Console.Title = $"Idling \"{Base.APP.Title}\" [{Base.APP.ID}] | Uptime: {Base.APP.UpTime}";

                if(playtime != Base.APP.Playtime)
                {
                    playtime = Base.APP.Playtime;
                    Console.WriteLine($"Total hours on record: {Base.APP.Playtime}");
                }
                Thread.Sleep(1 * 900);
            }
        });

        public static void Main(string[] args) => MainAsync(args.Length > 0 ? args[0] : "").GetAwaiter().GetResult();
         
        public static async Task MainAsync(string appID)
        {
            uint AppID = await ParseAppID(appID);
            string ApiKey = "";
            Base = new Core.Objects.Steam(ApiKey, AppID);
             
            if (await Base.Connect())
            {
                DynamicTextThread.Start();

                //wait
                Console.WriteLine("Running! Press any key or close window to stop idling.");
                Console.ReadKey();

                //close 
                await Base.Disconnect();
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
