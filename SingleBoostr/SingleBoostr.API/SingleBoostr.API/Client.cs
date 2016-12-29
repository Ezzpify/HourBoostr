using SingleBoostr.API.Types;
using SingleBoostr.API.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SingleBoostr
{
    public class Client
    {
        private List<ICallback> Callbacks = new List<ICallback>();
        public SteamClient009 SteamClient;
        public SteamUser012 SteamUser;
        public SteamUserStats007 SteamUserStats;
        public SteamUtils005 SteamUtils;
        public SteamApps001 SteamApps001;
        public SteamApps003 SteamApps003;
        private int Pipe;
        private int User;
        private bool RunningCallbacks;

        ~Client()
        {
            if (this.SteamClient == null)
                return;
            this.SteamClient.ReleaseUser(this.Pipe, this.User);
            this.User = 0;
            this.SteamClient.ReleaseSteamPipe(this.Pipe);
            this.Pipe = 0;
        }

        public bool Initialize(long appId)
        {
            if (appId != 0L)
                Environment.SetEnvironmentVariable("SteamAppId", appId.ToString());

            if (Steam.GetInstallPath() == null || !Steam.Load())
                return false;

            this.SteamClient = Steam.CreateInterface<SteamClient009>("SteamClient009");
            if (this.SteamClient == null)
                return false;

            this.Pipe = this.SteamClient.CreateSteamPipe();
            if (this.Pipe == 0)
                return false;

            this.User = this.SteamClient.ConnectToGlobalUser(this.Pipe);
            if (this.User == 0)
                return false;

            this.SteamUtils = this.SteamClient.GetSteamUtils004(this.Pipe);
            if (appId > 0L && (int)this.SteamUtils.GetAppID() != (int)(uint)appId)
                return false;

            this.SteamUser = this.SteamClient.GetSteamUser012(this.User, this.Pipe);
            this.SteamUserStats = this.SteamClient.GetSteamUserStats006(this.User, this.Pipe);
            this.SteamApps001 = this.SteamClient.GetSteamApps001(this.User, this.Pipe);
            this.SteamApps003 = this.SteamClient.GetSteamApps003(this.User, this.Pipe);

            return true;
        }

        public TCallback CreateAndRegisterCallback<TCallback>() where TCallback : ICallback, new()
        {
            TCallback callback = new TCallback();
            this.Callbacks.Add((ICallback)callback);
            return callback;
        }

        public void RunCallbacks(bool server)
        {
            if (this.RunningCallbacks)
                return;

            this.RunningCallbacks = true;
            CallbackMessage message = new CallbackMessage();
            int call = 0;

            while (Steam.GetCallback(this.Pipe, ref message, ref call))
            {
                foreach (ICallback callback in this.Callbacks.Where<ICallback>((Func<ICallback, bool>)(candidate =>
                {
                    if (candidate.Id == message.m_iCallback)
                        return candidate.Server == server;

                    return false;

                }))) callback.Run(message.m_pubParam);

                Steam.FreeLastCallback(this.Pipe);
            }

            this.RunningCallbacks = false;
        }
    }
}
