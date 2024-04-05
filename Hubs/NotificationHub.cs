using Microsoft.AspNetCore.SignalR;
using SignalRwithEntityFramework.Models;
using SignalRwithEntityFramework.Repos;

namespace SignalRwithEntityFramework.Hubs;

public class NotificationHub : Hub
{
    private readonly HubCache _hubCache;

    public NotificationHub(HubCache hubCache)
    {
        _hubCache = hubCache;
    }

    public async Task SendNotificationToAll(string message)
    {
        await Clients.All.SendAsync("ReceivedNotification", message);
    }

    public async Task SendNotificationToClient(string message, string username)
    {
        var hubConnections = _hubCache.connections.Where(con => con.Username == username).ToList();

        foreach (var hubConnection in hubConnections)
        {
            await Clients.Client(hubConnection.ConnectionId).SendAsync("ReceivedPersonalNotification", message, username);
        }
    }

    public override Task OnConnectedAsync()
    {
        Clients.Caller.SendAsync("OnConnected");
        return base.OnConnectedAsync();
    }

    public async Task SaveUserConnection(string username)
    {
        var connectionId = Context.ConnectionId;

        var hubConnection = new HubConnection
        {
            ConnectionId = connectionId,
            Username = username
        };

        _hubCache.connections.Add(hubConnection); 
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var hubConnection = _hubCache.connections.FirstOrDefault(con => con.ConnectionId == Context.ConnectionId);

        if(hubConnection != null)
        {
            _hubCache.connections.Remove(hubConnection); 
        }

        return base.OnDisconnectedAsync(exception);
    }
}
