using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using SteamKit2;
using SteamKit2.Internal;
using System.Security.Cryptography;

namespace HourBoostr
{
    class BotClass
    {
        /// <summary>
        /// Bot variables
        /// </summary>
        public List<int>                _Games;
        public SteamClient              _SteamClient;
        private SteamUser               _SteamUser;
        private SteamUser.LogOnDetails  _LogOnDetails;
        private CallbackManager         _CBManager;

        private string  _SentryPath;
        private string  _AuthCode;
        private string  _Nounce;
        public string   _Username;
        private string  _Password;

        public bool     _IsRunning;
        public bool     _IsLoggedIn;

        
        /// <summary>
        /// Thread variables
        /// </summary>
        private Thread  _CBThread;


        /// <summary>
        /// Main initializer for each account
        /// </summary>
        /// <param name="info"></param>
        public BotClass(Config.AccountInfo info)
        {
            /*Assign bot info*/
            _Username   = info.Username;
            _Password   = info.Password;
            _Games      = info.Games;

            /*Sentryfiles*/
            _SentryPath = Path.Combine(Application.StartupPath, String.Format("Sentryfiles\\{0}.sentry", info.Username));

            /*LogOn details class*/
            _LogOnDetails = new SteamUser.LogOnDetails()
            {
                Username = info.Username,
                Password = info.Password
            };

            /*Assign clients*/
            _SteamClient    = new SteamClient();
            _CBManager      = new CallbackManager(_SteamClient);
            _SteamUser      = _SteamClient.GetHandler<SteamUser>();

            /*Assign Callbacks*/
            new Callback<SteamClient.ConnectedCallback>(OnConnected, _CBManager);
            new Callback<SteamClient.DisconnectedCallback>(OnDisconnected, _CBManager);
            new Callback<SteamUser.LoggedOnCallback>(OnLoggedOn, _CBManager);
            new Callback<SteamUser.UpdateMachineAuthCallback>(OnMachineAuth, _CBManager);

            /*Connect to Steam*/
            _SteamClient.Connect();
            _IsRunning = true;

            /*Start Callback thread*/
            _CBThread = new Thread(RunCallback);
            _CBThread.Start();
        }


        /// <summary>
        /// Writes to console with time and username
        /// </summary>
        /// <param name="str"></param>
        private void Log(string str)
        {
            string time = DateTime.Now.ToString("d/M/yyyy HH:mm:ss");
            Console.WriteLine("  {0} {1} - {2}", time, _Username, str);
        }


        /// <summary>
        /// Continues the callbacks
        /// Terminates if Bot stops or Thread _callbackThread is killed
        /// </summary>
        private void RunCallback()
        {
            while(_IsRunning)
            {
                _CBManager.RunWaitCallbacks(TimeSpan.FromSeconds(1));
            }
        }


        /// <summary>
        /// OnConnected Callback
        /// Fires when Client connects to Steam
        /// </summary>
        /// <param name="callback"></param>
        private void OnConnected(SteamClient.ConnectedCallback callback)
        {
            /*Login - NOT OK*/
            if(callback.Result != EResult.OK)
            {
                Log("(OnConnected) EResult not OK");
                _IsRunning = false;
                return;
            }

            /*Set sentry hash*/
            byte[] sentryHash = null;
            if (File.Exists(_SentryPath))
            {
                byte[] sentryFile = File.ReadAllBytes(_SentryPath);
                sentryHash = CryptoHelper.SHAHash(sentryFile);
            }

            /*Set new auth codes*/
            Log("Connected! Logging in...");
            _LogOnDetails.AuthCode = _AuthCode;
            _LogOnDetails.SentryFileHash = sentryHash;

            /*Attempt to login*/
            _SteamUser.LogOn(_LogOnDetails);
        }


        /// <summary>
        /// OnDisconnected Callback
        /// Fires when Client disconnects from Steam
        /// Will also fire when setting up an account to re-auth
        /// </summary>
        /// <param name="callback"></param>
        private void OnDisconnected(SteamClient.DisconnectedCallback callback)
        {
            /*Only reconnect if the bot is still in running state*/
            _IsLoggedIn = false;
            if(_IsRunning)
            {
                Log("Reconnecting in 3s...");
                Thread.Sleep(3000);
                _SteamClient.Connect();
            }
        }


        /// <summary>
        /// OnLoggedOn Callback
        /// Fires when User logs in successfully
        /// </summary>
        /// <param name="callback"></param>
        private void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            /*Fetch if SteamGuard is required*/
            if (callback.Result == EResult.AccountLogonDenied)
            {
                /*SteamGuard required, tell user to enter the code*/
                Log("This account is SteamGuard protected.");
                Log("Write the code recieved in your email:");
                _AuthCode = Console.ReadLine();
                return;
            }

            /*Something terrible has happened*/
            if(callback.Result != EResult.OK)
            {
                /*Incorrect password*/
                if(callback.Result == EResult.InvalidPassword)
                {
                    Log(String.Format("{0} - Incorrect password! Try again:", callback.Result));
                    _LogOnDetails.Password = Config.Password.ReadPassword();
                    _SteamClient.Disconnect();
                    return;
                }

                /*Something else happened that I didn't account for*/
                Log(String.Format("{0} - Something failed. Redo process please.", callback.Result));
                _IsLoggedIn = false;
                return;
            }

            /*Logged in successfully*/
            Log("Successfully logged in!\n");
            _Nounce = callback.WebAPIUserNonce;
            _IsLoggedIn = true;

            /*Set games playing*/
            SetGamesPlaying();
        }


        /// <summary>
        /// OnMachineAuth Callback
        /// Fires when User is authenticating the Steam account
        /// </summary>
        /// <param name="callback"></param>
        private void OnMachineAuth(SteamUser.UpdateMachineAuthCallback callback)
        {
            /*Handles Sentry file for auth*/
            int fileSize;
            byte[] sentryHash;
            using (var fs = File.Open(_SentryPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                /*Fetch data*/
                fs.Seek(callback.Offset, SeekOrigin.Begin);
                fs.Write(callback.Data, 0, callback.BytesToWrite);
                fileSize = (int)fs.Length;

                fs.Seek(0, SeekOrigin.Begin);
                using (var sha = new SHA1CryptoServiceProvider())
                {
                    sentryHash = sha.ComputeHash(fs);
                }
            }

            /*Inform steam servers that we're accepting this sentry file*/
            _SteamUser.SendMachineAuthResponse(new SteamUser.MachineAuthDetails
            {
                /*Set the information recieved*/
                JobID = callback.JobID,
                FileName = callback.FileName,

                BytesWritten = callback.BytesToWrite,
                FileSize = fileSize,
                Offset = callback.Offset,

                Result = EResult.OK,
                LastError = 0,

                OneTimePassword = callback.OneTimePassword,
                SentryFileHash = sentryHash,
            });
        }


        /// <summary>
        /// Set the game currently playing for cooler looks lel
        /// </summary>
        /// <param name="id"></param>
        private void SetGamesPlaying()
        {
            /*Set up requested games*/
            var gamesPlaying = new SteamKit2.ClientMsgProtobuf<CMsgClientGamesPlayed>(EMsg.ClientGamesPlayed);
            foreach(int Game in _Games)
            {
                gamesPlaying.Body.games_played.Add(new CMsgClientGamesPlayed.GamePlayed
                {
                    game_id = new GameID(Game),
                });
            }

            /*Tell the client that we're playing these games*/
            _SteamClient.Send(gamesPlaying);
        }
    }
}
