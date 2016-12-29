using Microsoft.Win32;
using SingleBoostr.API.Types;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SingleBoostr
{
    public static class Steam
    {
        private static IntPtr Handle = IntPtr.Zero;
        private static Steam.NativeCreateInterface CallCreateInterface;
        private static Steam.NativeSteamBGetCallback CallSteamBGetCallback;
        private static Steam.NativeSteamFreeLastCallback CallSteamFreeLastCallback;

        private static Delegate GetExportDelegate<TDelegate>(IntPtr module, string name)
        {
            IntPtr procAddress = Steam.Native.GetProcAddress(module, name);
            if (procAddress == IntPtr.Zero)
                return (Delegate)null;

            return Marshal.GetDelegateForFunctionPointer(procAddress, typeof(TDelegate));
        }

        private static TDelegate GetExportFunction<TDelegate>(IntPtr module, string name) where TDelegate : class
        {
            return (TDelegate)Convert.ChangeType(Steam.GetExportDelegate<TDelegate>(module, name), typeof(TDelegate));
        }

        public static string GetInstallPath()
        {
            return (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\Valve\\Steam", "InstallPath", (object)null);
        }

        public static TClass CreateInterface<TClass>(string version) where TClass : INativeWrapper, new()
        {
            IntPtr objectAddress = Steam.CallCreateInterface(version, IntPtr.Zero);
            if (objectAddress == IntPtr.Zero)
                return default(TClass);

            TClass @class = new TClass();
            @class.SetupFunctions(objectAddress);
            return @class;
        }

        public static bool GetCallback(int pipe, ref CallbackMessage message, ref int call)
        {
            return Steam.CallSteamBGetCallback(pipe, ref message, ref call);
        }

        public static bool FreeLastCallback(int pipe)
        {
            return Steam.CallSteamFreeLastCallback(pipe);
        }

        public static bool Load()
        {
            if (Steam.Handle != IntPtr.Zero)
                return true;

            string installPath = Steam.GetInstallPath();
            if (installPath == null)
                return false;

            Steam.Native.SetDllDirectory(installPath + ";" + Path.Combine(installPath, "bin"));
            IntPtr module = Steam.Native.LoadLibraryEx(Path.Combine(installPath, "steamclient.dll"), IntPtr.Zero, 8U);
            if (module == IntPtr.Zero)
                return false;

            Steam.CallCreateInterface = Steam.GetExportFunction<Steam.NativeCreateInterface>(module, "CreateInterface");
            if (Steam.CallCreateInterface == null)
                return false;

            Steam.CallSteamBGetCallback = Steam.GetExportFunction<Steam.NativeSteamBGetCallback>(module, "Steam_BGetCallback");
            if (Steam.CallSteamBGetCallback == null)
                return false;

            Steam.CallSteamFreeLastCallback = Steam.GetExportFunction<Steam.NativeSteamFreeLastCallback>(module, "Steam_FreeLastCallback");
            if (Steam.CallSteamFreeLastCallback == null)
                return false;

            Steam.Handle = module;
            return true;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        private struct Native
        {
            internal const uint LOAD_WITH_ALTERED_SEARCH_PATH = 8;

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr LoadLibraryEx(string lpszLib, IntPtr hFile, uint dwFlags);

            [DllImport("kernel32.dll", SetLastError = true)]
            internal static extern IntPtr SetDllDirectory(string lpPathName);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private delegate IntPtr NativeCreateInterface(string version, IntPtr returnCode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool NativeSteamBGetCallback(int pipe, ref CallbackMessage message, ref int call);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool NativeSteamFreeLastCallback(int pipe);
    }
}
