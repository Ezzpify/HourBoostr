using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;

namespace HourBoostr
{
    class Functions
    {
        /// <summary>
        /// Get method
        /// </summary>
        /// <param name="URL">Url to fetch string from</param>
        /// <returns></returns>
        public string Fetch(string URL)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = wc.DownloadString(URL);
                    return HtmlResult;
                }
                catch (Exception ex)
                {
                    return "0";
                }
            }
        }


        /// <summary>
        /// Get image stream from url
        /// </summary>
        /// <param name="url">Url to fetch image from</param>
        /// <returns></returns>
        public Image ImageFromUrl(string url)
        {
            try
            {
                var request = WebRequest.Create(url);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
            catch
            {
                return null;
            }
        }

        public string GetStringBetween(string source, string start, string end)
        {
            int startIndex = source.IndexOf(start);
            if (startIndex != -1)
            {
                int endIndex = source.IndexOf(end, startIndex + 1);
                if (endIndex != -1)
                {
                    return source.Substring(startIndex + start.Length, endIndex - startIndex - start.Length);
                }
            }
            return string.Empty;
        }
    }
}
