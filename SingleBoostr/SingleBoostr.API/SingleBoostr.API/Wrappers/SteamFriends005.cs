using SingleBoostr.API.Interfaces;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SingleBoostr.API.Wrappers
{
    public class SteamFriends005 : NativeWrapper<ISteamFriends005>
    {
        public string GetPersonaName()
        {
            /*https://github.com/rlabrecque/Steamworks.NET/blob/d617ccdb85db1ca72af8c020e55196d7e03a53bf/Plugins/Steamworks.NET/InteropHelp.cs#L36*/
            var nativeUtf8 = this.Call<IntPtr, SteamFriends005.NativeGetPersonaName>(this.Functions.GetPersonaName, (object)this.ObjectAddress);

            if (nativeUtf8 == IntPtr.Zero)
                return null;

            int len = 0;
            while (Marshal.ReadByte(nativeUtf8, len) != 0)
                ++len;

            if (len == 0)
                return string.Empty;

            byte[] buffer = new byte[len];
            Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetPersonaName(IntPtr thisObject);
    }
}
