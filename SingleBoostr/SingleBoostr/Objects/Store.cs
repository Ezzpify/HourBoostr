using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace SingleBoostr.objects
{
    public class Store
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