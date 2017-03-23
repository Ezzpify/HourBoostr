using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;

namespace SingleBoostr
{
    class UpdateCheck
    {
        public static async Task<bool> IsUpdateAvailable()
        {
            string newest = await DownloadString(Const.VERSION_FILE_URL);
            if (!string.IsNullOrWhiteSpace(newest) && new Regex(@"^[0-9.]+$").IsMatch(newest))
            {
                var availableVersion = new Version(newest);
                var versionCurrent = new Version(Application.ProductVersion);
                return versionCurrent.CompareTo(availableVersion) < 0;
            }

            return false;
        }

        private static async Task<string> DownloadString(string url)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36");
                    return await wc.DownloadStringTaskAsync(url);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
    }
}
