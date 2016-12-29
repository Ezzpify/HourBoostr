using System;
using SingleBoostr;

namespace SingleBoostrGame
{
    class Program
    {
        private static Client _client;

        static void Main(string[] args)
        {
            long appId = 0;
            if (args.Length > 0 && long.TryParse(args[0], out appId))
            {
                if (appId == 0)
                    return;

                if (args.Length == 2)
                    Console.Title = args[1];

                _client = new Client();
                if (_client.Initialize(appId))
                {
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Title = "SingleBoostr.Game :: Missing arguments";
                Console.WriteLine("Missing arguments:\n - appId (long)\n - gameName (string) (opional)");
                Console.WriteLine("\n\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
