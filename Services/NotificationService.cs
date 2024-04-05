using SignalRwithEntityFramework.Hubs;
using SignalRwithEntityFramework.Models;
using TableDependency.SqlClient;

namespace SignalRwithEntityFramework.Services
{
    public class NotificationService : INotificationService
    {
        SqlTableDependency<Notification> notifications;
        NotificationHub notificationHub;

        public NotificationService(NotificationHub notificationHub)
        {
            this.notificationHub = notificationHub;
        } 

        public async Task SendNotification(Notification notification)
        {
            if (notification.MessageType == "All")
            {
                await notificationHub.SendNotificationToAll(notification.Message);
            }
            else if (notification.MessageType == "Personal")
            {
                await notificationHub.SendNotificationToClient(notification.Message, notification.Username);
            } 
        }
    }
}
