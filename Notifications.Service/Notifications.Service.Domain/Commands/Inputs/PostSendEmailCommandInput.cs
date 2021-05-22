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
               .IsNotNullOrWhiteSpace(From, "From", "This value is not valid!")
               .IsNotNullOrWhiteSpace(FromName, "FromName", "This value is not valid!")
               .IsNotNullOrWhiteSpace(To, "To", "This value is not valid!")
               .IsNotNullOrWhiteSpace(Subject, "Subject", "This value is not valid!")
               .IsNotNullOrWhiteSpace(Message, "Message", "This value is not valid!")
                );
        }
    }
}
