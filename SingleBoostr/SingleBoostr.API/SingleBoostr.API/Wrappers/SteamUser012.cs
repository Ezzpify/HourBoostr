using SingleBoostr.API.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace SingleBoostr.API.Wrappers
{
  public class SteamUser012 : NativeWrapper<ISteamUser012>
  {
    [return: MarshalAs(UnmanagedType.I1)]
    public bool IsLoggedIn()
    {
        return this.Call<bool, SteamUser012.NativeLoggedOn>(this.Functions.LoggedOn, new object[1]
        {
            (object) this.ObjectAddress
        });
    }

    public ulong GetSteamID()
    {
        SteamUser012.NativeGetSteamID function = this.GetFunction<SteamUser012.NativeGetSteamID>(this.Functions.GetSteamID);
        ulong steamId = 0;
        function(this.ObjectAddress, ref steamId);
        return steamId;
    }

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeLoggedOn(IntPtr thisObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void NativeGetSteamID(IntPtr thisObject, ref ulong steamId);
  }
}
