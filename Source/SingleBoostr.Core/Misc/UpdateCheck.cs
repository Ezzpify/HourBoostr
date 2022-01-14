using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using RestSharp;
using Newtonsoft.Json;
using SingleBoostr.Core.Objects;

namespace SingleBoostr.Core.Misc
{
    public class Updater
    {
        /// <summary>
        /// Gets name of given assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns>assembly name</returns>
        private static string GetName(Assembly assembly) => assembly.GetName().Name;

        /// <summary>
        /// Downloads json list of assembly's that we handle though updater
        /// </summary>
        /// <param name="url"></param>
        /// <returns>json list of of object(Application)</returns>
        private static async Task<List<Application>> DownloadConfig(string url)
        {
            var response = await new RestClient(url).ExecuteAsync(new RestRequest());
            return response.StatusCode == HttpStatusCode.OK ? JsonConvert.DeserializeObject<UpdateHolder>(response.Content).Applications : null;
        }

        /// <summary>
        /// Get local version of given assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns>local version of given assembly</returns>
        public static string GetLocalVersion(Assembly assembly)
        {
            switch (GetName(assembly).ToLower())
            {
                case "singleboostr": return Const.SingleBoostr.VERSION;
                case "hourboostr": return Const.HourBoostr.VERSION;
                default: return "0.0.0";
            }
        }

        /// <summary>
        /// Get server version of given assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns>server version of given assembly</returns>
        public static async Task<string> GetServerVersion(Assembly assembly)
        {
            var apps = await DownloadConfig(Const.GitHub.VERSION_FILE_URL);
            var app = apps.Where(x => x.Name.ToLower().Equals(GetName(assembly).ToLower())).First();
            return app.Version;
        }

        /// <summary>
        /// Does given assembly have update available
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns>true if update, false if not </returns>
        public static async Task<bool> UpdateAvailable(Assembly assembly)
        {
            var serverVersion = await GetServerVersion(assembly); 
            return !GetLocalVersion(assembly).Equals(serverVersion);
        }

        /// <summary>
        /// Check if given assembly have update available
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns>information about update or empty string if no update</returns>
        public static async Task<string> Check(Assembly assembly)
        {
            var apps = await DownloadConfig(Const.GitHub.VERSION_FILE_URL);
            var app = apps.Where(x => x.Name.ToLower().Equals(GetName(assembly).ToLower())).First();
            var hasUpdate = await UpdateAvailable(assembly);
            return hasUpdate ? app.Info : string.Empty;
        }
    }
}