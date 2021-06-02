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

            bool sendEmail = await _sendGridService.SendEmail(command.To, command.From, command.FromName, command.Subject, command.Message);

            if (!sendEmail)
                return new GenericCommandResult(false, "It was not possible to send your email !", null, StatusCodes.Status403Forbidden, command.Notifications);


            return new GenericCommandResult(true, "Your email sent successfully!", null, StatusCodes.Status200OK, command.Notifications);
        }

        public async ValueTask<GenericCommandResult> Handle(PostSendSmsCommmandInput command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Incorrect  data!", null, StatusCodes.Status400BadRequest, command.Notifications);

           
            return new GenericCommandResult(true, "Your SMS sent successfully!", null, StatusCodes.Status200OK, command.Notifications);
        }
    }
}
