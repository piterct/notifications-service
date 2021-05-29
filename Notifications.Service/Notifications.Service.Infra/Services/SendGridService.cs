using Microsoft.Extensions.Options;
using Notifications.Service.Domain.Entities;
using Notifications.Service.Domain.Services.SendGrid;
using Notifications.Service.Shared.Settings;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Service.Infra.Services
{
    public class SendGridService : ISendGridService
    {
        private readonly SendGridSettings _sendGridSettings;
        public SendGridService(IOptions<SendGridSettings> sendGridSettings)
        {
            _sendGridSettings = sendGridSettings.Value;
        }
        public async ValueTask<bool> SendEmail(string destination, string emailFrom, string nameFrom, string subject, string body, string cc = "", string cco = "", List<AttachmentFile> attachmentPathList = null)
        {
            var to = new List<EmailAddress>();
            var apiKey = _sendGridSettings.Password;
            var client = new SendGridClient(_sendGridSettings.Password);
            var from = new EmailAddress(emailFrom, nameFrom);

            var arrayDestination = destination.Split(";");
            if (arrayDestination.Length > 0)
            {
                foreach (var item in arrayDestination)
                {
                    to.Add(new EmailAddress { Email = item });
                }
            }

            var htmlContent = body;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, string.Empty, htmlContent, true);

            if (!string.IsNullOrWhiteSpace(cc))
            {
                var arrayCcs = cc.Split(";");
                if (arrayCcs.Length > 0)
                {
                    var ccs = arrayCcs.ToList().Select(x => new EmailAddress(x)).ToList();
                    msg.AddCcs(ccs);
                }
            }

            if (!string.IsNullOrWhiteSpace(cco))
            {
                var arrayBccs = cco.Split(";");
                if (arrayBccs.Length > 0)
                {
                    var bccs = arrayBccs.ToList().Select(x => new EmailAddress(x)).ToList();
                    msg.AddBccs(bccs);
                }
            }

            if (attachmentPathList != null)
            {
                foreach (var attachmentPath in attachmentPathList)
                {
                    if (attachmentPathList.Count > 0)
                    {
                        msg.AddAttachment(attachmentPath.FileName, attachmentPath.Base64);
                    }
                }

            }

            var response = await client.SendEmailAsync(msg);

            return response.StatusCode.ToString() == "Accepted" ? true : false;
        }
    }
}
