using System;
using System.Runtime.InteropServices;

namespace SingleBoostr.API.Interfaces
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ISteamUser012
    {
        public IntPtr GetHSteamUser;
        public IntPtr LoggedOn;
        public IntPtr GetSteamID;
        public IntPtr InitiateGameConnection;
        public IntPtr TerminateGameConnection;
        public IntPtr TrackAppUsageEvent;
        public IntPtr GetUserDataFolder;
        public IntPtr StartVoiceRecording;
        public IntPtr StopVoiceRecording;
        public IntPtr GetCompressedVoice;
        public IntPtr DecompressVoice;
        public IntPtr GetAuthSessionTicket;
        public IntPtr BeginAuthSession;
        public IntPtr EndAuthSession;
        public IntPtr CancelAuthTicket;
        public IntPtr UserHasLicenseForApp;
    }
}
