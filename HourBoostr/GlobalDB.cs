using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace HourBoostr
{
    /*
     * Credits for this part goes to JustArchi at:
     * https://github.com/JustArchi/ArchiSteamFarm
     */

    class GlobalDB : IDisposable
    {
        private static readonly JsonSerializerSettings CustomSerializerSettings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>(2) {
                new IPAddressConverter(),
                new IPEndPointConverter()
            }
        };

        [JsonProperty(Required = Required.DisallowNull)]
        internal readonly Guid Guid = Guid.NewGuid();

        [JsonProperty(Required = Required.DisallowNull)]
        internal readonly InMemoryServerListProvider ServerListProvider = new InMemoryServerListProvider();

        private readonly object FileLock = new object();

        internal uint CellID
        {
            get { return _CellID; }
            set
            {
                if ((value == 0) || (_CellID == value))
                {
                    return;
                }

                _CellID = value;
                Save();
            }
        }

        [JsonProperty(Required = Required.DisallowNull)]
        private uint _CellID;

        private string FilePath;

        // This constructor is used when creating new database
        private GlobalDB(string filePath) : this() {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            FilePath = filePath;
            Save();
        }

        // This constructor is used only by deserializer
        private GlobalDB()
        {
            ServerListProvider.ServerListUpdated += OnServerListUpdated;
        }

        public void Dispose()
        {
            ServerListProvider.ServerListUpdated -= OnServerListUpdated;
            ServerListProvider.Dispose();
        }

        internal static GlobalDB Load(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            if (!File.Exists(filePath))
            {
                return new GlobalDB(filePath);
            }

            GlobalDB globalDatabase;

            try
            {
                globalDatabase = JsonConvert.DeserializeObject<GlobalDB>(File.ReadAllText(filePath), CustomSerializerSettings);
            }
            catch (Exception e)
            {
                return null;
            }

            if (globalDatabase == null)
            {
                return null;
            }

            globalDatabase.FilePath = filePath;
            return globalDatabase;
        }

        private void OnServerListUpdated(object sender, EventArgs e) => Save();

        private void Save()
        {
            string json = JsonConvert.SerializeObject(this, CustomSerializerSettings);
            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            lock (FileLock)
            {
                for (byte i = 0; i < 5; i++)
                {
                    try
                    {
                        File.WriteAllText(FilePath, json);
                        break;
                    }
                    catch (Exception e)
                    {

                    }

                    Thread.Sleep(1000);
                }
            }
        }
    }

    class IPAddressConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(IPAddress);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            return IPAddress.Parse(token.Value<string>());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IPAddress ip = (IPAddress)value;
            writer.WriteValue(ip.ToString());
        }
    }

    class IPEndPointConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(IPEndPoint);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            IPAddress address = jo["Address"].ToObject<IPAddress>(serializer);
            ushort port = jo["Port"].Value<ushort>();
            return new IPEndPoint(address, port);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IPEndPoint ep = (IPEndPoint)value;
            writer.WriteStartObject();
            writer.WritePropertyName("Address");
            serializer.Serialize(writer, ep.Address);
            writer.WritePropertyName("Port");
            writer.WriteValue(ep.Port);
            writer.WriteEndObject();
        }
    }
}
