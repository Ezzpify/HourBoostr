using System;
using System.Runtime.InteropServices;

namespace HourBoostr.Idler.VTables
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ISteamAppsVTable
    {
        public IntPtr GetAppData;
        private IntPtr DTorISteamApps0011;
    };
}
