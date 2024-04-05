using Microsoft.AspNetCore.Mvc;
using SignalRwithEntityFramework.Models;
using SignalRwithEntityFramework.Repos;
using SignalRwithEntityFramework.Services;

namespace SignalRwithEntityFramework.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(
            INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NotificationUser([FromBody] Notification notification)
        {
            await _notificationService.SendNotification(notification);

            return Ok();
        }
    }
}
