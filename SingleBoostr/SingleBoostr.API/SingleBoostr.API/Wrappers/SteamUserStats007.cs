using SingleBoostr.API.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace SingleBoostr.API.Wrappers
{
  public class SteamUserStats007 : NativeWrapper<ISteamUserStats007>
  {
    [return: MarshalAs(UnmanagedType.I1)]
    public bool RequestCurrentStats()
    {
        return this.Call<bool, SteamUserStats007.NativeRequestCurrentStats>(this.Functions.RequestCurrentStats, new object[1]
        {
            (object) this.ObjectAddress
        });
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool GetStatValue(string name, ref int value)
    {
        return this.GetFunction<SteamUserStats007.NativeGetStatInt>(this.Functions.GetStatInteger)(this.ObjectAddress, name, ref value);
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool GetStatValue(string name, ref float value)
    {
        return this.GetFunction<SteamUserStats007.NativeGetStatFloat>(this.Functions.GetStatFloat)(this.ObjectAddress, name, ref value);
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool SetStatValue(string name, int value)
    {
        return this.Call<bool, SteamUserStats007.NativeSetStatInt>(this.Functions.SetStatInteger, (object) this.ObjectAddress, (object) name, (object) value);
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool SetStatValue(string name, float value)
    {
        return this.Call<bool, SteamUserStats007.NativeSetStatFloat>(this.Functions.SetStatFloat, (object) this.ObjectAddress, (object) name, (object) value);
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool GetAchievementState(string name, ref bool achieved)
    {
        return this.GetFunction<SteamUserStats007.NativeGetAchievement>(this.Functions.GetAchievement)(this.ObjectAddress, name, ref achieved);
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool SetAchievement(string name, bool state)
    {
        if (!state)
            return this.Call<bool, SteamUserStats007.NativeClearAchievement>(this.Functions.ClearAchievement, (object) this.ObjectAddress, (object) name);
        return this.Call<bool, SteamUserStats007.NativeSetAchievement>(this.Functions.SetAchievement, (object) this.ObjectAddress, (object) name);
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool StoreStats()
    {
        return this.Call<bool, SteamUserStats007.NativeStoreStats>(this.Functions.StoreStats, new object[1]
        {
            (object) this.ObjectAddress
        });
    }

    public int GetAchievementIcon(string name)
    {
        return this.Call<int, SteamUserStats007.NativeGetAchievementIcon>(this.Functions.GetAchievementIcon, (object) this.ObjectAddress, (object) name);
    }

    public string GetAchievementDisplayAttribute(string name, string key)
    {
        return this.Call<string, SteamUserStats007.NativeGetAchievementDisplayAttribute>(this.Functions.GetAchievementDisplayAttribute, (object) this.ObjectAddress, (object) name, (object) key);
    }

    [return: MarshalAs(UnmanagedType.I1)]
    public bool ResetAllStats(bool achievementsToo)
    {
        return this.Call<bool, SteamUserStats007.NativeResetAllStats>(this.Functions.ResetAllStats, (object) this.ObjectAddress, (object) achievementsToo);
    }

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeRequestCurrentStats(IntPtr thisObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeGetStatInt(IntPtr thisObject, string pchName, ref int pData);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeGetStatFloat(IntPtr thisObject, string pchName, ref float pData);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeSetStatInt(IntPtr thisObject, string pchName, int nData);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeSetStatFloat(IntPtr thisObject, string pchName, float fData);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeGetAchievement(IntPtr thisObject, string pchName, ref bool pbAchieved);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeSetAchievement(IntPtr thisObject, string pchName);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: MarshalAs(UnmanagedType.I1)]
    private delegate bool NativeClearAchievement(IntPtr thisObject, string pchName);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeStoreStats(IntPtr thisObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate int NativeGetAchievementIcon(IntPtr thisObject, string pchName);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate string NativeGetAchievementDisplayAttribute(IntPtr thisObject, string pchName, string pchKey);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeResetAllStats(IntPtr thisObject, bool bAchievementsToo);
  }
}
