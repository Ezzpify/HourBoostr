using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SteamKit2.Discovery;

namespace HourBoostr
{
    /*
     * Credits for this part goes to JustArchi at:
     * https://github.com/JustArchi/ArchiSteamFarm
     */

    class InMemoryServerListProvider : IDisposable, IServerListProvider
    {
        [JsonProperty(Required = Required.DisallowNull)]
        private readonly ConcurrentHashSet<IPEndPoint> Servers = new ConcurrentHashSet<IPEndPoint>();

        public void Dispose() => Servers.Dispose();
        public Task<IEnumerable<IPEndPoint>> FetchServerListAsync() => Task.FromResult<IEnumerable<IPEndPoint>>(Servers);

        public Task UpdateServerListAsync(IEnumerable<IPEndPoint> endPoints)
        {
            if (endPoints == null)
            {
                return Task.Delay(0);
            }

            HashSet<IPEndPoint> newServers = new HashSet<IPEndPoint>(endPoints);

            if (!Servers.ReplaceIfNeededWith(newServers))
            {
                return Task.Delay(0);
            }

            ServerListUpdated?.Invoke(this, EventArgs.Empty);
            return Task.Delay(0);
        }

        Task<IEnumerable<ServerRecord>> IServerListProvider.FetchServerListAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateServerListAsync(IEnumerable<ServerRecord> endpoints)
        {
            throw new NotImplementedException();
        }

        internal event EventHandler ServerListUpdated;
    }
}
