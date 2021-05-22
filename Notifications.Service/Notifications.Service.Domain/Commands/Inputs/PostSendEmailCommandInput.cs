using Flunt.Notifications;
using Flunt.Validations;
using Notifications.Service.Shared.Commands.Contracts;

namespace Notifications.Service.Domain.Commands.Inputs
{
    public class PostSendEmailCommandInput : Notifiable, ICommand
    {
        public string From { get; set; }
        public string FromName { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public void Validate()
        {

            AddNotifications(
           new Contract()
               .Requires()
               .IsNotNull(From, "From", "This value is not valid!")
               .IsNotNull(FromName, "FromName", "This value is not valid!")
               .IsNotNull(To, "Sender", "This value is not valid!")
               .IsNotNull(Subject, "Subject", "This value is not valid!")
               .IsNotNull(Message, "Message", "This value is not valid!")
                );
        }
    }
}
