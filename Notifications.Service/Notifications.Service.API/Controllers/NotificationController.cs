using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notifications.Service.Domain.Commands.Inputs;
using System;
using System.Threading.Tasks;

namespace Notifications.Service.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class NotificationController : BaseController
    {

        private readonly ILogger<NotificationController> _logger;

        public NotificationController(ILogger<NotificationController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("sendEmail")]
        public async ValueTask<IActionResult> SendEmail(PostSendEmailCommandInput command)
        {
            try
            {

                return GetResult(true);
            }
            catch (Exception exception)
            {
                _logger.LogError("An exception has occurred at {dateTime}. " +
                 "Exception message: {message}." +
                 "Exception Trace: {trace}", DateTime.UtcNow, exception.Message, exception.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
