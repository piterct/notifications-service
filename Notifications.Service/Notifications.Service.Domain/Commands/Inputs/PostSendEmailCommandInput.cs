using Flunt.Notifications;
using Flunt.Validations;
using Notifications.Service.Shared.Commands.Contracts;

namespace Notifications.Service.Domain.Commands.Inputs
{
    public class PostSendEmailCommandInput : Notifiable, ICommand
    {
        public string Sender { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public void Validate()
        {

            AddNotifications(
           new Contract()
               .Requires()
               .IsNotNull(Sender, "Sender", "This value is not valid!")
               .IsNotNull(To, "Sender", "This value is not valid!")
               .IsNotNull(Subject, "Subject", "This value is not valid!")
               .IsNotNull(Message, "Message", "This value is not valid!")
                );
        }
    }
}
