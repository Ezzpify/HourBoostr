using SingleBoostr.API.Interfaces;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SingleBoostr.API.Wrappers
{
    public class SteamApps001 : NativeWrapper<ISteamApps001>
    {
        public string GetAppData(uint appId, string key)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.EnsureCapacity(1024);
            if (this.Call<int, SteamApps001.NativeGetAppData>(this.Functions.GetAppData, (object) this.ObjectAddress, (object) appId, (object) key, (object) stringBuilder, (object) stringBuilder.Capacity) == 0)
                return (string) null;

            return stringBuilder.ToString();
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetAppData(IntPtr thisObject, uint nAppID, string pchKey, StringBuilder pchValue, int cchValueMax);
    }
}
