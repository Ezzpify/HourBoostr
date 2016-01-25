using System.Net;

namespace HourBoostrJsonHelper
{
    static class Website
    {
        /// <summary>
        /// Downloads a string from the internet from the specified url
        /// </summary>
        /// <param name="URL">Url to download string from</param>
        /// <returns>Returns string of url website source</returns>
        public static string DownloadString(string URL)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    return wc.DownloadString(URL);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
    }
}
