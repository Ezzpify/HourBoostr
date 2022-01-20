using System;
using System.Runtime.InteropServices;
using HourBoostr.Idler.Core;
using HourBoostr.Idler.VTables;

namespace HourBoostr.Idler.Interfaces
{
    [InteropHelp.InterfaceVersion("SteamClient017")]
    public class ISteamClient : InteropHelp.NativeWrapper<ISteamClientVTable>
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate int NativeCreateSteamPipe(IntPtr thisptr);
        public int CreateSteamPipe() => GetFunction<NativeCreateSteamPipe>(Functions.CreateSteamPipe)(ObjectAddress);
        
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate int NativeConnectToGlobalUserI(IntPtr thisptr, int hSteamPipe);
        public Int32 ConnectToGlobalUser(int hSteamPipe) => GetFunction<NativeConnectToGlobalUserI>(Functions.ConnectToGlobalUser)(ObjectAddress, hSteamPipe);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamUserIIS(IntPtr thisptr, int hSteamUser, Int32 hSteamPipe, string pchVersion);
        public TClass GetISteamUser<TClass>(int hSteamUser, int hSteamPipe) where TClass : InteropHelp.INativeWrapper, new() => InteropHelp.CastInterface<TClass>(GetFunction<NativeGetISteamUserIIS>(Functions.GetISteamUser)(ObjectAddress, hSteamUser, hSteamPipe, Utils.GetInterfaceIdentifier(typeof(TClass))));

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamAppsIIS(IntPtr thisptr, int hSteamUser, int hSteamPipe, string pchVersion);
        public TClass GetISteamApps<TClass>(int hSteamUser, int hSteamPipe) where TClass : InteropHelp.INativeWrapper, new() => InteropHelp.CastInterface<TClass>(GetFunction<NativeGetISteamAppsIIS>(Functions.GetISteamApps)(ObjectAddress, hSteamUser, hSteamPipe, Utils.GetInterfaceIdentifier(typeof(TClass))));
    };
}
