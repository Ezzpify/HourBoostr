using System;
using System.Threading.Tasks; 
using System.Net;
using RestSharp;
using Newtonsoft.Json;
using SingleBoostr.Core.Objects;
using System.Reflection;
using System.Linq;

namespace SingleBoostr.Core.Misc
{
    public class UpdateCheck
    {
        public static async Task<string> IsUpdateAvailable(Assembly assembly)
        {
            var resp = await new RestClient("https://raw.githubusercontent.com/Ni1kko/HourBoostr/master/version.json").ExecuteTaskAsync(new RestRequest()); 
            if (resp.StatusCode != HttpStatusCode.OK) return string.Empty;

            if (JsonConvert.DeserializeObject<UpdateHolder>(resp.Content).Applications.Where(x => x.Name.ToLower().Equals(assembly.GetName().Name.ToLower())).First() is Application App)
            {  
                return assembly.GetName().Version.ToString().Equals(App.Version) ? string.Empty : App.Info;
            }

            return string.Empty;
        }
    }
}
