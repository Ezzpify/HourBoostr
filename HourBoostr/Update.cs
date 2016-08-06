using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HourBoostr
{
    class Update
    {
        /// <summary>
        /// Downloads the data from an online text file
        /// Compares text file data to product version to see if there's an update available
        /// </summary>
        /// <returns></returns>
        public static bool IsUpdateAvailable()
        {
            var reg = new Regex(@"^[0-9.]+$");

            string version = DownloadString(EndPoint.VERSION_FILE);
            if (!string.IsNullOrWhiteSpace(version) && reg.IsMatch(version))
                return version != Application.ProductVersion;

            return false;
        }


        /// <summary>
        /// Downloads a string from the internet from the specified url
        /// </summary>
        /// <param name="url">Url to download string from</param>
        /// <returns>Returns string of url website source</returns>
        private static string DownloadString(string url)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36");
                    return wc.DownloadString(url);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
    }
}
