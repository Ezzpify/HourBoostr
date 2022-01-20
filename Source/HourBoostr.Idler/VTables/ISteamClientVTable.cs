using System;
using System.Runtime.InteropServices;

namespace HourBoostr.Idler.VTables
{ 
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ISteamClientVTable
    {
        public IntPtr CreateSteamPipe;
        public IntPtr BReleaseSteamPipe;
        public IntPtr ConnectToGlobalUser;
        public IntPtr CreateLocalUser;
        public IntPtr ReleaseUser;
        public IntPtr GetISteamUser;
        public IntPtr GetISteamGameServer;
        public IntPtr SetLocalIPBinding;
        public IntPtr GetISteamFriends;
        public IntPtr GetISteamUtils;
        public IntPtr GetISteamMatchmaking;
        public IntPtr GetISteamMatchmakingServers;
        public IntPtr GetISteamGenericInterface;
        public IntPtr GetISteamUserStats;
        public IntPtr GetISteamGameServerStats;
        public IntPtr GetISteamApps;
    };
}
