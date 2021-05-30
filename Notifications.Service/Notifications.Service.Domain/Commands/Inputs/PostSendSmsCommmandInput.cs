using Flunt.Notifications;
using Flunt.Validations;
using Notifications.Service.Shared.Commands.Contracts;

namespace Notifications.Service.Domain.Commands.Inputs
{
    public class PostSendSmsCommmandInput : Notifiable, ICommand
    {
        public string To { get; set; }
        public string Message { get; set; }

        public void Validate()
        {

            AddNotifications(
           new Contract()
               .Requires()
               .IsNotNullOrEmpty(To, "To", "This value is not valid!")
               .IsNotNullOrEmpty(Message, "Message", "This value is not valid!")
                );
        }
    }
}
