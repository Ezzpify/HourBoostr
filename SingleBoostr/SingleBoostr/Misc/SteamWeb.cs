using System;
using System.Net;
using System.Threading.Tasks;
using SingleBoostr.Ui;

namespace SingleBoostr.Misc
{
    class SteamWeb : WebClient
    {
        private CookieContainer _cookies;
        private SessionInfo _session;
        private Log _log;

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = _cookies;
            }

            return request;
        }

        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
        {
            try
            {
                var baseResponse = base.GetWebResponse(request);
                var cookies = (baseResponse as HttpWebResponse).Cookies;

                if (cookies.Count > 0)
                {
                    /*Check if cookie should be deleted. This means that sessionID is now invalid and user has to log in again.*/
                    if (cookies["steamLogin"] != null && cookies["steamLogin"].Value == "deleted")
                    {
                        _session.SessionId = string.Empty;
                        _session.SteamLogin = string.Empty;
                        _session.SteamParental = string.Empty;
                        _session.SteamMachineAuth = string.Empty;
                        _session.SteamRememberLogin = string.Empty;
                    }
                }
                
                return baseResponse;
            }
            catch (Exception ex)
            {
                _log.Write(Log.LogLevel.Error, $"Error at GetWebResponse with: {ex.Message}");
                return null;
            }
        }

        private CookieContainer generateCookies()
        {
            var cookies = new CookieContainer();
            var target = new Uri("http://steamcommunity.com");

            cookies.Add(new Cookie("sessionid", _session.SessionId) { Domain = target.Host });
            cookies.Add(new Cookie("steamLogin", _session.SteamLogin) { Domain = target.Host });
            cookies.Add(new Cookie("steamparental", _session.SteamParental) { Domain = target.Host });
            cookies.Add(new Cookie("steamRememberLogin", _session.SteamRememberLogin) { Domain = target.Host });
            cookies.Add(new Cookie(GetSteamMachineAuthCookieName(), _session.SteamMachineAuth) { Domain = target.Host });

            return cookies;
        }

        private string GetSteamMachineAuthCookieName()
        {
            if (_session.SteamLogin != null && _session.SteamLogin.Length > 17)
                return string.Format("steamMachineAuth{0}", _session.SteamLogin.Substring(0, 17));

            return "steamMachineAuth";
        }

        public async Task<string> Request(string url)
        {
            try
            {
                _cookies = generateCookies();
                return await DownloadStringTaskAsync(url);
            }
            catch (Exception ex)
            {
                _log.Write(Log.LogLevel.Error, $"Error downloading string at '{url}' with error: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<byte[]> RequestData(string url)
        {
            try
            {
                _cookies = generateCookies();
                return await DownloadDataTaskAsync(url);
            }
            catch (Exception ex)
            {
                _log.Write(Log.LogLevel.Error, $"Error downloading data at '{url}' with error: {ex.Message}");
                return null;
            }
        }

        public SteamWeb(SessionInfo session)
        {
            _log = new Log("SteamWeb.txt");
            _session = session;
        }
    }
}