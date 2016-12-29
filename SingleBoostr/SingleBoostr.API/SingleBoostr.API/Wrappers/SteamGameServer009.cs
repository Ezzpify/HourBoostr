// Decompiled with JetBrains decompiler
// Type: SAM.API.Wrappers.SteamGameServer009
// Assembly: SAM.API, Version=6.3.0.804, Culture=neutral, PublicKeyToken=null
// MVID: 7DF108F6-41E2-4750-9029-3DA2C808D0A1
// Assembly location: E:\Dropbox\SPARA\Develop\HourBoostr\SingleBoostr\SingleBoostr\SAM.API.dll

using SingleBoostr.API.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace SingleBoostr.API.Wrappers
{
  public class SteamGameServer009 : NativeWrapper<ISteamGameServer009>
  {
    public int LogOn()
    {
        return this.Call<int, SteamGameServer009.NativeLogOn>(this.Functions.LogOn, new object[1]
        {
            (object) this.ObjectAddress
        });
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool SetServerType(uint a, uint b, ushort c, ushort d, ushort e, string f, string g, bool h)
    {
        return this.Call<bool, SteamGameServer009.NativeSetServerType>(this.Functions.SetServerType, (object) this.ObjectAddress, (object) a, (object) b, (object) c, (object) d, (object) e, (object) f, (object) g, (object) h);
    }

    public ulong GetSteamID()
    {
        ulong steamId = 0;
        this.GetFunction<SteamGameServer009.NativeGetSteamID>(this.Functions.GetSteamID)(this.ObjectAddress, ref steamId);
        return steamId;
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool SendUserConnectAndAuthenticate(uint host, byte[] data, ref ulong steamId)
    {
        return this.GetFunction<SteamGameServer009.NativeSendUserConnectAndAuthenticate>(this.Functions.SendUserConnectAndAuthenticate)(this.ObjectAddress, host, data, data.Length, ref steamId);
    }

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate int NativeLogOn(IntPtr thisObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall, CharSet = CharSet.Ansi)]
    private delegate bool NativeSetServerType(IntPtr thisObject, uint a, uint b, ushort c, ushort d, ushort e, string f, string g, bool h);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void NativeGetSteamID(IntPtr thisObject, ref ulong steamId);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall, CharSet = CharSet.Ansi)]
    private delegate bool NativeSendUserConnectAndAuthenticate(IntPtr thisObject, uint host, byte[] data, int length, ref ulong steamId);
  }
}
