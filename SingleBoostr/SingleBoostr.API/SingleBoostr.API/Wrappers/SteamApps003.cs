using System;
using System.Runtime.InteropServices;
using SingleBoostr.API.Interfaces;

namespace SingleBoostr.API.Wrappers
{
    public class SteamApps003 : NativeWrapper<ISteamApps003>
    {
        public bool IsSubscribedApp(long nGameID)
        {
            return this.Call<bool, SteamApps003.NativeIsSubscribedApp>(this.Functions.IsSubscribedApp, (IntPtr)this.ObjectAddress, (uint)nGameID);
        }

        public string GetCurrentGameLanguage()
        {
            return Marshal.PtrToStringAnsi(this.Call<IntPtr, SteamApps003.NativeGetCurrentGameLanguage>(this.Functions.GetCurrentGameLanguage, new object[1]
            {
                (object) this.ObjectAddress
            }));
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        [return: MarshalAs(UnmanagedType.I1)]
        private delegate bool NativeIsSubscribedApp(IntPtr thisobj, UInt32 appID);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr NativeGetCurrentGameLanguage(IntPtr thisObject);
    }
}
