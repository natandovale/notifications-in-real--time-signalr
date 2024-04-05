using SignalRwithEntityFramework.Models;

namespace SignalRwithEntityFramework.Repos
{
    public class HubCache
    {
        public List<HubConnection> connections;

        public HubCache()
        {
            connections = new List<HubConnection>();
        }

        public HubConnection GetCacheConection(string userName)
        {
            return connections?.FirstOrDefault(c => c.Username == userName);
        }

        public void AddCacheConection(HubConnection hub)
        {
            connections.Add(hub);
        }

        public void RemoveCacheConection(string userName)
        {
            var hub = GetCacheConection(userName);
            connections?.Remove(hub);
        }
    }
}
