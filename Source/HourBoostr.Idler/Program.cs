using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using HourBoostr.Idler.Core;
using HourBoostr.Idler.Interfaces;
using HourBoostr.Idler.Objects;

namespace HourBoostr.Idler
{
    internal class Program
    {
        internal static Program This { get; private set; }
        internal ProgramAssembly Assembly { get; init; }
        internal ProgramArguments Arguments { get; init; }  
        internal ISteamClient SteamClient { get; private set; }
        internal ISteamApps SteamApps001 { get; private set; }
        private int User { get; set; } = 0;
        private int Pipe { get; set; } = 0;
        
        private SteamApp SteamApp { get; init; }
        private Thread DynamicTextThread { get; init; }
        private uint AppID { get; init; }

        private static IntPtr SteamClientHandle = IntPtr.Zero;
        private static IntPtr SteamHandle = IntPtr.Zero;

        private struct Native
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr LoadLibraryEx(string lpszLib, IntPtr hFile, UInt32 dwFlags);

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr SetDllDirectory(string lpPathName);

            internal const UInt32 LOAD_WITH_ALTERED_SEARCH_PATH = 8;

            [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            internal delegate IntPtr _f(string version);

            [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            internal delegate IntPtr CreateInterface(string version, IntPtr returnCode);

            // helper
            internal static TDelegate GetExportFunction<TDelegate>(IntPtr module, string name) where TDelegate : class
            {
                IntPtr address = Native.GetProcAddress(module, name);

                if (address == IntPtr.Zero)
                    return null;

                return (TDelegate)(object)Marshal.GetDelegateForFunctionPointer(address, typeof(TDelegate));
            }
        }
        private static Native.CreateInterface CallCreateInterface;
        private static Native._f CallCreateSteamInterface;

        internal Program(List<string> arguments)
        {
            Assembly = new();
            Arguments = new(arguments);
            if (Arguments.MultiBoostr)
            {

            }
            else
            {
                AppID = Arguments.AppID.ParseAppID();
                SteamApp = new(AppID);
                SteamApp.Start();
                DynamicTextThread = new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    while (true)
                    {
                        Console.Title = $"Idling \"{This.SteamApp.Title}\" [{This.SteamApp.ID}] | Uptime: {This.SteamApp.UpTime}";
                        Thread.Sleep(1 * 900);
                    }
                });
            }
        }
         
        public static async Task Main(string[] args)
        {
            This = new(args.ToList());

            if (This.Arguments.MultiBoostr)
            {

            }
            else
            {
                static async Task<bool> Connect()
                {
                    if (!This.Load(true)) return false;
                    if (Environment.CurrentDirectory == This.GetInstallPath()) return false;
                     
                    This.SteamClient = This.CreateInterface<ISteamClient>();
                    if (This.SteamClient == null) return false;
                     
                    This.Pipe = This.SteamClient.CreateSteamPipe();
                    if (This.Pipe == 0) return false;

                    await Task.Delay(500);

                    This.User = This.SteamClient.ConnectToGlobalUser(This.Pipe);
                    if (This.User == 0 || This.User == -1) return false;
                     
                    This.SteamApps001 = This.SteamClient.GetISteamApps<ISteamApps>(This.User, This.Pipe);
                    if (This.SteamApps001 == null) return false;

                    return true;
                }

                if (await Connect())
                {
                    //start threads
                    This.DynamicTextThread.Start();

                    //wait
                    Console.WriteLine("Running! Press any key or close window to stop idling.");
                    Console.ReadKey();

                    //Stop idler
                    This.SteamApp.Stop();

                    //Stop threads
                    This.DynamicTextThread.Abort();

                    //Kill App
                    Environment.Exit(-1);

                }
            }
        }
        
        public TClass CreateInterface<TClass>() where TClass : InteropHelp.INativeWrapper, new()
        {
            if (CallCreateInterface == null)
                throw new InvalidOperationException("Steam4NET library has not been initialized.");

            IntPtr address = CallCreateInterface(Utils.GetInterfaceIdentifier(typeof(TClass)), IntPtr.Zero);

            if (address == IntPtr.Zero)
                return default;

            var rez = new TClass();
            rez.SetupFunctions(address);

            return rez;
        }
        public TClass CreateSteamInterface<TClass>() where TClass : InteropHelp.INativeWrapper, new()
        {
            if (CallCreateSteamInterface == null)
                throw new InvalidOperationException("Steam4NET library has not been initialized.");

            IntPtr address = CallCreateSteamInterface(Utils.GetInterfaceIdentifier(typeof(TClass)));

            if (address == IntPtr.Zero)
                return default;

            var rez = new TClass();
            rez.SetupFunctions(address);

            return rez;
        }

        private string GetInstallPath() => Path.GetFullPath((string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam", "SteamPath", null));
        private bool Load(bool steam) => steam && !LoadSteam() ? false : LoadSteamClient();
        private bool LoadSteam()
        {
            if (SteamHandle != IntPtr.Zero)
                return true;

            string path = GetInstallPath();
            if (!string.IsNullOrEmpty(path))
                Native.SetDllDirectory(path + ";" + Path.Combine(path, "bin"));

            path = Path.Combine(path, "steam.dll");

            IntPtr module = Native.LoadLibraryEx(path, IntPtr.Zero, Native.LOAD_WITH_ALTERED_SEARCH_PATH);

            if (module == IntPtr.Zero)
                return false;

            CallCreateSteamInterface = Native.GetExportFunction<Native._f>(module, "_f");

            if (CallCreateSteamInterface == null)
                return false;

            SteamHandle = module;

            return true;
        }
        private bool LoadSteamClient()
        {
            if (SteamClientHandle != IntPtr.Zero)
                return true;

            string path = GetInstallPath();

            if (!string.IsNullOrEmpty(path))
                Native.SetDllDirectory(path + ";" + Path.Combine(path, "bin"));
            if (Environment.Is64BitProcess)
                path = Path.Combine(path, "steamclient64.dll");
            else
                path = Path.Combine(path, "steamclient.dll");
            IntPtr module = Native.LoadLibraryEx(path, IntPtr.Zero, Native.LOAD_WITH_ALTERED_SEARCH_PATH);

            if (module == IntPtr.Zero)
                return false;

            CallCreateInterface = Native.GetExportFunction<Native.CreateInterface>(module, "CreateInterface");
            if (CallCreateInterface == null)
                return false;

            SteamClientHandle = module;

            return true;
        }
    }
}
