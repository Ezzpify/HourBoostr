using SingleBoostr.API.Interfaces;
using SingleBoostr.API.Types;
using System;
using System.Runtime.InteropServices;

namespace SingleBoostr.API.Wrappers
{
  public class SteamClient009 : NativeWrapper<ISteamClient009>
  {
    public int CreateSteamPipe()
    {
        return this.Call<int, SteamClient009.NativeCreateSteamPipe>(this.Functions.CreateSteamPipe, new object[1]
        {
        (object) this.ObjectAddress
        });
    }

    public bool ReleaseSteamPipe(int pipe)
    {
        return this.Call<bool, SteamClient009.NativeReleaseSteamPipe>(this.Functions.ReleaseSteamPipe, new object[2]
        {
            (object) this.ObjectAddress, pipe
        });
    }

    public int CreateLocalUser(ref int pipe, AccountType type)
    {
        return this.GetFunction<SteamClient009.NativeCreateLocalUser>(this.Functions.CreateLocalUser)(this.ObjectAddress, ref pipe, type);
    }

    public int ConnectToGlobalUser(int pipe)
    {
        return this.Call<int, SteamClient009.NativeConnectToGlobalUser>(this.Functions.ConnectToGlobalUser, (object) this.ObjectAddress, (object) pipe);
    }

    public void ReleaseUser(int pipe, int user)
    {
        this.Call<SteamClient009.NativeReleaseUser>(this.Functions.ReleaseUser, (object) this.ObjectAddress, (object) pipe, (object) user);
    }

    public void SetLocalIPBinding(uint host, ushort port)
    {
        this.Call<SteamClient009.NativeSetLocalIPBinding>(this.Functions.SetLocalIPBinding, (object) this.ObjectAddress, (object) host, (object) port);
    }

    private TClass GetISteamUser<TClass>(int user, int pipe, string version) where TClass : INativeWrapper, new()
    {
        IntPtr objectAddress = this.Call<IntPtr, SteamClient009.NativeGetISteamUser>(this.Functions.GetISteamUser, (object) this.ObjectAddress, (object) user, (object) pipe, (object) version);
        TClass @class = new TClass();
        @class.SetupFunctions(objectAddress);
        return @class;
    }

    private TClass GetISteamFriends<TClass>(int user, int pipe, string version) where TClass : INativeWrapper, new()
    {
        IntPtr objectAddress = this.Call<IntPtr, SteamClient009.NativeGetISteamFriends>(this.Functions.GetISteamFriends, (object)this.ObjectAddress, (object)user, (object)pipe, (object)version);
        TClass @class = new TClass();
        @class.SetupFunctions(objectAddress);
        return @class;
    }

    public SteamFriends005 GetSteamFriends005(int user, int pipe)
    {
        return this.GetISteamFriends<SteamFriends005>(user, pipe, "SteamFriends005");
    }

    public SteamUser012 GetSteamUser012(int user, int pipe)
    {
        return this.GetISteamUser<SteamUser012>(user, pipe, "SteamUser012");
    }

    private TClass GetISteamGameServer<TClass>(int user, int pipe, string version) where TClass : INativeWrapper, new()
    {
        IntPtr objectAddress = this.Call<IntPtr, SteamClient009.NativeGetISteamGameServer>(this.Functions.GetISteamGameServer, (object) this.ObjectAddress, (object) user, (object) pipe, (object) version);
        TClass @class = new TClass();
        @class.SetupFunctions(objectAddress);
        return @class;
    }

    public SteamGameServer009 GetSteamGameServer009(int user, int pipe)
    {
        return this.GetISteamGameServer<SteamGameServer009>(user, pipe, "SteamGameServer009");
    }

    private TClass GetISteamUserStats<TClass>(int user, int pipe, string version) where TClass : INativeWrapper, new()
    {
        IntPtr objectAddress = this.Call<IntPtr, SteamClient009.NativeGetISteamUserStats>(this.Functions.GetISteamUserStats, (object) this.ObjectAddress, (object) user, (object) pipe, (object) version);
        TClass @class = new TClass();
        @class.SetupFunctions(objectAddress);
        return @class;
    }

    public SteamUserStats007 GetSteamUserStats006(int user, int pipe)
    {
        return this.GetISteamUserStats<SteamUserStats007>(user, pipe, "STEAMUSERSTATS_INTERFACE_VERSION007");
    }

    public TClass GetISteamUtils<TClass>(int pipe, string version) where TClass : INativeWrapper, new()
    {
        IntPtr objectAddress = this.Call<IntPtr, SteamClient009.NativeGetISteamUtils>(this.Functions.GetISteamUtils, (object) this.ObjectAddress, (object) pipe, (object) version);
        TClass @class = new TClass();
        @class.SetupFunctions(objectAddress);
        return @class;
    }

    public SteamUtils005 GetSteamUtils004(int pipe)
    {
        return this.GetISteamUtils<SteamUtils005>(pipe, "SteamUtils005");
    }

    private TClass GetISteamApps<TClass>(int user, int pipe, string version) where TClass : INativeWrapper, new()
    {
        IntPtr objectAddress = this.Call<IntPtr, SteamClient009.NativeGetISteamApps>(this.Functions.GetISteamApps, (object) user, (object) pipe, (object) version);
        TClass @class = new TClass();
        @class.SetupFunctions(objectAddress);
        return @class;
    }

    public SteamApps001 GetSteamApps001(int user, int pipe)
    {
        return this.GetISteamApps<SteamApps001>(user, pipe, "STEAMAPPS_INTERFACE_VERSION001");
    }

    public SteamApps003 GetSteamApps003(int user, int pipe)
    {
        return this.GetISteamApps<SteamApps003>(user, pipe, "STEAMAPPS_INTERFACE_VERSION003");
    }

    private TClass GetISteamGenericInterface<TClass>(int user, int pipe, string name) where TClass : INativeWrapper, new()
    {
        IntPtr objectAddress = this.Call<IntPtr, SteamClient009.NativeGetISteamGenericInterface>(this.Functions.GetISteamGenericInterface, (object) this.ObjectAddress, (object) user, (object) pipe, (object) name);
        TClass @class = new TClass();
        @class.SetupFunctions(objectAddress);
        return @class;
    }

    public void SetWarningMessageHook(SteamClient009.SteamAPIWarningMessageHook hook)
    {
        this.Call<SteamClient009.NativeSetWarningMessageHook>(this.Functions.SetWarningMessageHook, (object) this.ObjectAddress, (object) hook);
    }

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate int NativeCreateSteamPipe(IntPtr thisObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate bool NativeReleaseSteamPipe(IntPtr thisobj, Int32 hSteamPipe);
    [return: MarshalAs(UnmanagedType.I1)]

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate int NativeCreateLocalUser(IntPtr thisObject, ref int pipe, AccountType type);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate int NativeConnectToGlobalUser(IntPtr thisObject, int pipe);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void NativeReleaseUser(IntPtr thisObject, int pipe, int user);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate void NativeSetLocalIPBinding(IntPtr thisObject, uint host, ushort port);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate IntPtr NativeGetISteamUser(IntPtr thisObject, int hSteamUser, int hSteamPipe, string pchVersion);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate IntPtr NativeGetISteamFriends(IntPtr thisObject, int hSteamUser, int hSteamPipe, string pchVersion);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate IntPtr NativeGetISteamGameServer(IntPtr thisObject, int hSteamUser, int hSteamPipe, string pchVersion);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate IntPtr NativeGetISteamUserStats(IntPtr thisObject, int hSteamUser, int hSteamPipe, string pchVersion);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate IntPtr NativeGetISteamUtils(IntPtr thisObject, int hSteamPipe, string pchVersion);

    private delegate IntPtr NativeGetISteamApps(int hSteamUser, int hSteamPipe, string pchVersion);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate IntPtr NativeGetISteamGenericInterface(IntPtr thisObject, int hSteamUser, int hSteamPipe, string pchVersion);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public delegate void SteamAPIWarningMessageHook(int pipe, string message);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    private delegate IntPtr NativeSetWarningMessageHook(IntPtr thisObject, SteamClient009.SteamAPIWarningMessageHook hook);
  }
}
