using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Notifications.Service.Domain.Commands.Inputs;
using Notifications.Service.Shared.Commands;
using System.Threading.Tasks;

namespace Notifications.Service.Domain.Handlers
{
    public class NotificationHandler : Notifiable
    {
        public async ValueTask<GenericCommandResult> Handle(PostSendEmailCommandInput command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Incorrect  data!", null, StatusCodes.Status400BadRequest, command.Notifications);


            return new GenericCommandResult(true, "Success!", null, StatusCodes.Status200OK, command.Notifications);
        }
    }
}
