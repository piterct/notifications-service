using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Notifications.Service.Domain.Commands.Inputs;
using Notifications.Service.Domain.Services.SendGrid;
using Notifications.Service.Shared.Commands;
using System.Threading.Tasks;

namespace Notifications.Service.Domain.Handlers
{
    public class NotificationHandler : Notifiable
    {
        private readonly ISendGridService _sendGridService;

        public NotificationHandler(ISendGridService sendGridService)
        {
            _sendGridService = sendGridService;
        }
        public async ValueTask<GenericCommandResult> Handle(PostSendEmailCommandInput command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Incorrect  data!", null, StatusCodes.Status400BadRequest, command.Notifications);

            await _sendGridService.SendEmail(command.To, command.From, command.FromName, command.Subject, command.Message);

            return new GenericCommandResult(true, "Success!", null, StatusCodes.Status200OK, command.Notifications);
        }
    }
}
