using SingleBoostr.API.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace SingleBoostr.API.Wrappers
{
  public class SteamUtils005 : NativeWrapper<ISteamUtils005>
  {
    public int GetConnectedUniverse()
    {
        return this.Call<int, SteamUtils005.NativeGetConnectedUniverse>(this.Functions.GetConnectedUniverse, new object[1]
        {
            (object) this.ObjectAddress
        });
    }

    public string GetIPCountry()
    {
        return this.Call<string, SteamUtils005.NativeGetIPCountry>(this.Functions.GetIPCountry, new object[1]
        {
            (object) this.ObjectAddress
        });
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool GetImageSize(int index, ref int width, ref int height)
    {
        return this.GetFunction<SteamUtils005.NativeGetImageSize>(this.Functions.GetImageSize)(this.ObjectAddress, index, ref width, ref height);
    }

    public bool GetImageRGBA(int index, byte[] data)
    {
        return this.GetFunction<SteamUtils005.NativeGetImageRGBA>(this.Functions.GetImageRGBA)(this.ObjectAddress, index, data, data.Length);
    }

    public uint GetAppID()
    {
        return this.Call<uint, SteamUtils005.NativeGetAppID>(this.Functions.GetAppID, new object[1]
        {
            (object) this.ObjectAddress
        });
    }

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate int NativeGetConnectedUniverse(IntPtr thisObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate string NativeGetIPCountry(IntPtr thisObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeGetImageSize(IntPtr thisObject, int iImage, ref int pnWidth, ref int pnHeight);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: MarshalAs(UnmanagedType.I1)]
    private delegate bool NativeGetImageRGBA(IntPtr thisObject, int iImage, byte[] pubDest, int nDestBufferSize);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate uint NativeGetAppID(IntPtr thisObject);
  }
}
