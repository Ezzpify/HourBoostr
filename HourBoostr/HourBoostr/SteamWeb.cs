using System;
using System.IO;
using System.Collections.Specialized;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using SteamKit2;

namespace HourBoostr
{
    /// <summary>
    /// https://github.com/Jessecar96/SteamBot/blob/master/SteamTrade/SteamWeb.cs
    /// </summary>
    public class SteamWeb
    {
        public const string mSteamCommunityDomain = "steamcommunity.com";
        public string mToken { get; private set; }
        public string mSessionId { get; private set; }
        public string mTokenSecure { get; private set; }
        private CookieContainer mCookieContainer = new CookieContainer();


        public string Fetch(string url, string method, NameValueCollection data = null, bool ajax = true, string referer = "")
        {
            using (HttpWebResponse response = Request(url, method, data, ajax, referer))
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream))
                return reader.ReadToEnd();
        }


        public HttpWebResponse Request(string url, string method, NameValueCollection data = null, bool ajax = true, string referer = "")
        {
            //Append the data to the URL for GET-requests
            bool isGetMethod = (method.ToLower() == "get");
            string dataString = (data == null ? null : string.Join("&", Array.ConvertAll(data.AllKeys, key =>
                string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(data[key]))
            )));

            if (isGetMethod && !string.IsNullOrEmpty(dataString))
            {
                url += (url.Contains("?") ? "&" : "?") + dataString;
            }

            //Setup the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Accept = "application/json, text/javascript;q=0.9, */*;q=0.5";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            request.Referer = string.IsNullOrEmpty(referer) ? "http://steamcommunity.com/trade/1" : referer;
            request.Timeout = 10000; //Timeout after 50 seconds
            request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Revalidate);
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            if (ajax)
            {
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Headers.Add("X-Prototype-Version", "1.7");
            }

            // Cookies
            request.CookieContainer = mCookieContainer;

            // Write the data to the body for POST and other methods
            if (!isGetMethod && !string.IsNullOrEmpty(dataString))
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);
                request.ContentLength = dataBytes.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(dataBytes, 0, dataBytes.Length);
                }
            }

            // Get the response
            return request.GetResponse() as HttpWebResponse;
        }
        

        public bool Authenticate(string myUniqueId, SteamClient client, string myLoginKey)
        {
            mToken = mTokenSecure = "";
            mSessionId = Convert.ToBase64String(Encoding.UTF8.GetBytes(myUniqueId));
            mCookieContainer = new CookieContainer();

            using (dynamic userAuth = WebAPI.GetInterface("ISteamUserAuth"))
            {
                // generate an AES session key
                var sessionKey = CryptoHelper.GenerateRandomBlock(32);

                // rsa encrypt it with the public key for the universe we're on
                byte[] cryptedSessionKey = null;
                using (RSACrypto rsa = new RSACrypto(KeyDictionary.GetPublicKey(client.ConnectedUniverse)))
                {
                    cryptedSessionKey = rsa.Encrypt(sessionKey);
                }

                byte[] loginKey = new byte[20];
                Array.Copy(Encoding.ASCII.GetBytes(myLoginKey), loginKey, myLoginKey.Length);

                // aes encrypt the loginkey with our session key
                byte[] cryptedLoginKey = CryptoHelper.SymmetricEncrypt(loginKey, sessionKey);

                KeyValue authResult;

                try
                {
                    authResult = userAuth.AuthenticateUser(
                        steamid: client.SteamID.ConvertToUInt64(),
                        sessionkey: HttpUtility.UrlEncode(cryptedSessionKey),
                        encrypted_loginkey: HttpUtility.UrlEncode(cryptedLoginKey),
                        method: "POST",
                        secure: true
                        );
                }
                catch (Exception)
                {
                    mToken = mTokenSecure = null;
                    return false;
                }

                mToken = authResult["token"].AsString();
                mTokenSecure = authResult["tokensecure"].AsString();

                mCookieContainer.Add(new Cookie("sessionid", mSessionId, String.Empty, mSteamCommunityDomain));
                mCookieContainer.Add(new Cookie("steamLogin", mToken, String.Empty, mSteamCommunityDomain));
                mCookieContainer.Add(new Cookie("steamLoginSecure", mTokenSecure, String.Empty, mSteamCommunityDomain));

                return true;
            }
        }


        public bool VerifyCookies()
        {
            using (HttpWebResponse response = Request("http://steamcommunity.com/", "HEAD"))
                return response.Cookies["steamLogin"] == null || !response.Cookies["steamLogin"].Value.Equals("deleted");
        }


        public bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            // allow all certificates
            return true;
        }
    }
}