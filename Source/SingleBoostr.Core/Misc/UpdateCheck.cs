using System.Threading.Tasks; 
using System.Net;
using RestSharp;
using Newtonsoft.Json;
using SingleBoostr.Core.Objects;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace SingleBoostr.Core.Misc
{
    public class Updater
    {
        private const string jsonFileURL = "https://raw.githubusercontent.com/Ni1kko/HourBoostr/master/version.json";

        private static string GetName(Assembly assembly) => assembly.GetName().Name;
        private static string GetVersion(Assembly assembly) => assembly.GetName().Version.ToString();
        private static bool UpdateAvailable(Assembly assembly, Application App) => !GetVersion(assembly).Equals($"{App.Version}.0");

        private static async Task<List<Application>> DownloadConfig(string url)
        {
            var response = await new RestClient(url).ExecuteAsync(new RestRequest());
            return response.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<UpdateHolder>(response.Content).Applications : null;
        }

        public static async Task<string> Check(Assembly assembly)
        {
            var apps = await DownloadConfig(jsonFileURL);
            var app = apps.Where(x => x.Name.ToLower().Equals(GetName(assembly).ToLower())).First();
            return UpdateAvailable(assembly, app) ? app.Info : string.Empty;
        }
    }
}
