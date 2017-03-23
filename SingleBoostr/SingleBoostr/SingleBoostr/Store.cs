using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SingleBoostr
{
    class Store
    {
        public class Screenshot
        {
            public int id { get; set; }

            public string path_thumbnail { get; set; }

            public string path_full { get; set; }
        }

        public class Data
        {
            public List<Screenshot> screenshots { get; set; }
        }

        public class Appdata
        {
            public Data data { get; set; }
        }

        public static string GetAppScreenshotUrl(string storeJson)
        {
            if (!string.IsNullOrWhiteSpace(storeJson))
            {
                var jsonObject = JObject.Parse(storeJson);
                var jsonProperty = jsonObject.Properties().First();
                var appData = jsonProperty.Value.ToObject<Appdata>();

                if (appData != null)
                {
                    var screenshot = appData.data.screenshots.FirstOrDefault();
                    if (screenshot != null)
                        return screenshot.path_full.Replace("\\", "");
                }
            }

            return string.Empty;
        }
    }
}
