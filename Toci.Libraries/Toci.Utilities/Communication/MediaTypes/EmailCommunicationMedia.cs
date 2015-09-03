using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using Toci.Utilities.Abstraction.Communication;
using Toci.Utilities.Interfaces.Communication;

namespace Toci.Utilities.Communication.MediaTypes
{
    public class EmailCommunicationMedia : CommunicationMedia
    {
        //public string Path { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public Encoding Encoding { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public override bool Send(IMessage message)
        {
            var mail = new MailMessage();

            using (var smtpServer = new SmtpClient())
            {

                mail.From = new MailAddress(message.Sender.Email);
                mail.To.Add(message.Receiver.Email);
                mail.Subject = message.Topic;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Body = message.GetMessage();
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;

                smtpServer.EnableSsl = true;
                smtpServer.Port = Port;
                smtpServer.Host = Host;
                smtpServer.Credentials = new NetworkCredential(Login, Password);
                smtpServer.EnableSsl = true;
                smtpServer.DeliveryFormat = SmtpDeliveryFormat.International;
                smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpServer.Timeout = 10000;


                //attachment
                if (message.Attachments != null)
                foreach (var attachment in message.Attachments.Values.SelectMany(allAttachments => allAttachments))
                {
                    mail.Attachments.Add
                        (
                            new Attachment(attachment.GetAttachment(),attachment.AttachmentName)
                        );
                }

   

                try
                {
                    smtpServer.Send(mail);
                }
                catch (Exception ) 
                {
                   // e.Message.ToString();
                    return false;
                }
            }

            return true;
        }
        public string ExtractFileName(string path)
        {
            var positionStart = path.LastIndexOf('\\');
            var positionEnd = (path.Length);
            var fileName = path.Substring(positionStart, positionEnd - positionStart).Trim();

            return fileName;
        }
    }
}
