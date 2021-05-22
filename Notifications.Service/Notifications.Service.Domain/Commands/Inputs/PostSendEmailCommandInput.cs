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
               .IsNotNullOrEmpty(From, "From", "This value is not valid!")
               .IsNotNullOrEmpty(FromName, "FromName", "This value is not valid!")
               .IsNotNullOrEmpty(To, "To", "This value is not valid!")
               .IsNotNullOrEmpty(Subject, "Subject", "This value is not valid!")
               .IsNotNullOrEmpty(Message, "Message", "This value is not valid!")
                );
        }
    }
}
