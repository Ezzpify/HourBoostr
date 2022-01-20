using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HourBoostr.Idler.Core
{
    public static class Utils
    {
        internal static uint ParseAppID(this string appID)
        {
            static uint parseAppID(string appID)
            {
                if (string.IsNullOrEmpty(appID) || !uint.TryParse(appID, out uint AppID)) return 0;
                return AppID;
            }

            uint AppID = 0;
            if (string.IsNullOrEmpty(appID))
            {
                while (AppID < 1)
                {
                    Console.WriteLine("Enter appId of game you wish to boost:");
                    appID = Console.ReadLine().Trim();
                    AppID = parseAppID(appID);
                    Console.Clear();
                }
            }
            else
            {
                AppID = parseAppID(appID);
                if (AppID <= 0)
                {
                    Console.WriteLine($"ERROR: Unable to parse '{appID}' as an app id.\n\nPress any key to exit...");
                    Console.ReadKey();
                    return 0;
                }
            }
            return AppID;
        }

        public static string GetInterfaceIdentifier(Type steamClass)
        {
            foreach (InteropHelp.InterfaceVersionAttribute attribute in steamClass.GetCustomAttributes(typeof(InteropHelp.InterfaceVersionAttribute), false))
            {
                return attribute.Identifier;
            }

            throw new Exception("Version identifier not found for class " + steamClass);
        }
    }
}

//Workaround: compiler throws error (Predefined type 'System.Runtime.CompilerServices.IsExternalInit' is not defined or imported)
//because we're compiling .NET 5 features in .NET Framework
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}