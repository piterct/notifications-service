using Notifications.Service.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifications.Service.Domain.Services.SendGrid
{
    public interface ISendGridService
    {
        ValueTask<bool> SendEmail(string destination, string title, string body, string cc = "", string cco = "", List<AttachmentFile> attachmentPathList = null);
    }
}
