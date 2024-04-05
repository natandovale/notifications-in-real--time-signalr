using SignalRwithEntityFramework.Models;

namespace SignalRwithEntityFramework.Services;

public interface INotificationService
{
    Task SendNotification(Notification notification);
}
