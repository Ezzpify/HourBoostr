using System;
using System.Runtime.InteropServices;

namespace SingleBoostr.API.Interfaces
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ISteamApps003
    {
        public IntPtr IsSubscribed;
        public IntPtr IsLowViolence;
        public IntPtr IsCybercafe;
        public IntPtr IsVACBanned;
        public IntPtr GetCurrentGameLanguage;
        public IntPtr GetAvailableGameLanguages;
        public IntPtr IsSubscribedApp;
        public IntPtr IsDlcInstalled;
    }
}
