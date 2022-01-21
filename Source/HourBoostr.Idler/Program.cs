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
        internal ISteamClient SteamClient { get; set; }
        internal ISteamApps SteamApps { get; set; }
        private int User { get; set; } = 0;
        private int Pipe { get; set; } = 0;
        
        private SteamApp SteamApp { get; init; }
        private Thread DynamicTextThread { get; init; }
        private uint AppID { get; init; }

        private static IntPtr SteamClientHandle = IntPtr.Zero;
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
        private static Native.CreateInterface CallCreateSteamClientInterface;

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
                    static async Task<bool> InitSteamLibs()
                    {
                        string BoostrPath = Environment.CurrentDirectory;
                        string SteamPath = Path.GetFullPath((string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Valve\Steam", "SteamPath", null));

                        static async Task<bool> LoadSteamClientLib(string path)
                        {
                            if (string.IsNullOrEmpty(path) || !Directory.Exists(path)) return false;
                            if (SteamClientHandle != IntPtr.Zero) return true;
                            Native.SetDllDirectory(path + ";" + Path.Combine(path, "bin"));
                            path = Environment.Is64BitProcess ? Path.Combine(path, "steamclient64.dll") : Path.Combine(path, "steamclient.dll");

                            IntPtr module = Native.LoadLibraryEx(path, IntPtr.Zero, Native.LOAD_WITH_ALTERED_SEARCH_PATH);
                            if (module == IntPtr.Zero) return false;
                            await Task.Delay(500);

                            CallCreateSteamClientInterface = Native.GetExportFunction<Native.CreateInterface>(module, "CreateInterface");
                            if (CallCreateSteamClientInterface == null) return false;

                            SteamClientHandle = module;
                            return true;
                        }

                        return !SteamPath.Equals(BoostrPath) && await LoadSteamClientLib(SteamPath);
                    }

                    static TClass CreateSteamClientInterface<TClass>() where TClass : InteropHelp.INativeWrapper, new()
                    {
                        if (CallCreateSteamClientInterface == null) throw new InvalidOperationException($"steamclient{(Environment.Is64BitProcess ? "64" : "")}.dll has not been initialized");
                        IntPtr address = CallCreateSteamClientInterface(Utils.GetInterfaceIdentifier(typeof(TClass)), IntPtr.Zero);
                        if (address == IntPtr.Zero) return default;
                        var rez = new TClass();
                        rez.SetupFunctions(address);
                        return rez;
                    }

                    if (!await InitSteamLibs()) return false;

                    This.SteamClient = CreateSteamClientInterface<ISteamClient>();
                    if (This.SteamClient == null) return false;
                     
                    This.Pipe = This.SteamClient.CreateSteamPipe();
                    if (This.Pipe == 0) return false;
                     
                    This.User = This.SteamClient.ConnectToGlobalUser(This.Pipe);
                    if (This.User == 0 || This.User == -1) return false;
                     
                    This.SteamApps = This.SteamClient.GetISteamApps<ISteamApps>(This.User, This.Pipe);
                    if (This.SteamApps == null) return false;

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
    }
}
