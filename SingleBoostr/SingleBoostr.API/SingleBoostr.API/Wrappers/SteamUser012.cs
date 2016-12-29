// Decompiled with JetBrains decompiler
// Type: SAM.API.Wrappers.SteamUser012
// Assembly: SAM.API, Version=6.3.0.804, Culture=neutral, PublicKeyToken=null
// MVID: 7DF108F6-41E2-4750-9029-3DA2C808D0A1
// Assembly location: E:\Dropbox\SPARA\Develop\HourBoostr\SingleBoostr\SingleBoostr\SAM.API.dll

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
