using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notifications.Service.Domain.Commands.Inputs;
using Notifications.Service.Domain.Handlers;
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
        public async ValueTask<IActionResult> SendEmail(PostSendEmailCommandInput command, [FromServices] NotificationHandler handler)
        {
            try
            {
                var result = await handler.Handle(command);
                return GetResult(result);
            }
            catch (Exception exception)
            {
                _logger.LogError("An exception has occurred at {dateTime}. " +
                 "Exception message: {message}." +
                 "Exception Trace: {trace}", DateTime.UtcNow, exception.Message, exception.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("sendSms")]
        public async ValueTask<IActionResult> SendSms(PostSendEmailCommandInput command, [FromServices] NotificationHandler handler)
        {
            try
            {
                var result = await handler.Handle(command);
                return GetResult(result);
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
