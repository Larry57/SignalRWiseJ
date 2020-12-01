using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRBackEnd.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRBackEnd.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class NotificationSenderController : ControllerBase {
        IHubContext<NotificationHub> notification;

        private readonly ILogger<NotificationSenderController> _logger;

        public NotificationSenderController(ILogger<NotificationSenderController> logger, IHubContext<NotificationHub> notification) {
            _logger = logger;
            this.notification = notification;
            this.notification = notification;
        }

        [HttpGet]
        public Task Send(string message) {
            return notification.Clients.All.SendAsync("Message", message);
        }
    }
}
