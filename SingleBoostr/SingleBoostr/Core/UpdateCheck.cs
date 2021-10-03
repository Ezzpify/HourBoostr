using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using RestSharp;
using Newtonsoft.Json;
using SingleBoostr.objects;

namespace SingleBoostr.Core
{
    class UpdateCheck
    {
        public static async Task<string> IsUpdateAvailable()
        {
            var resp = await new RestClient(Const.VERSION_FILE_URL).ExecuteTaskAsync(new RestRequest()); 
            if (resp.StatusCode != HttpStatusCode.OK) return string.Empty;

            var update = JsonConvert.DeserializeObject<UpdateHolder>(resp.Content);
            var availableVersion = new Version(update.Version);
            var versionCurrent = new Version(Application.ProductVersion);
            return versionCurrent.CompareTo(availableVersion) < 0 ? update.Info : string.Empty;
        }
    }
}
