using System;
using System.Runtime.InteropServices;
using System.Text;
using HourBoostr.Idler.Core;

namespace HourBoostr.Idler.Interfaces
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ISteamAppsVTable
    {
        public IntPtr GetAppData;
        private IntPtr DTorISteamApps0011;
    };

    [InteropHelp.InterfaceVersion("STEAMAPPS_INTERFACE_VERSION001")]
    public class ISteamApps : InteropHelp.NativeWrapper<ISteamAppsVTable>
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate int NativeGetAppDataUSSI(IntPtr thisptr, uint nAppID, string pchKey, StringBuilder pchValue, int cchValueMax);
        public int GetAppData(uint nAppID, string pchKey, StringBuilder pchValue) => GetFunction<NativeGetAppDataUSSI>(Functions.GetAppData)(ObjectAddress, nAppID, pchKey, pchValue, pchValue.Capacity);
    };
}