using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;
using RestSharp;
using Newtonsoft.Json;

namespace SingleBoostr
{
    class UpdateCheck
    {
        public class UpdateHolder
        {
            public string Version { get; set; }

            public string Info { get; set; }
        }

        public static async Task<string> IsUpdateAvailable()
        {
            var req = new RestRequest();
            var resp = await new RestClient(Const.VERSION_FILE_URL).ExecuteTaskAsync(req);

            if (resp.StatusCode != HttpStatusCode.OK)
                return string.Empty;

            var update = JsonConvert.DeserializeObject<UpdateHolder>(resp.Content);
            var availableVersion = new Version(update.Version);
            var versionCurrent = new Version(Application.ProductVersion);
            return versionCurrent.CompareTo(availableVersion) < 0 ? update.Info : string.Empty;
        }
    }
}
