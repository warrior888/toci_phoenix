using System.Collections.Generic;
using Toci.Utilities.Abstraction.Communication;
using Toci.Utilities.Abstraction.User;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMessages;

namespace Toci.Utilities.Communication
{
    public class EmailMessage : Message
    {
        public EmailMessage()
        {
            
        }
        

        public EmailMessage(string topic, string[] content, User SenderUser, User RecieverUser, MessageType messageType, MessagePriority messagePriority,
            Dictionary<MessageAttachmentType, List<IMessageAttachment>> attachments)
        {
            this.MessageMediaType = MessageMediaType.Email;
            this.MessageType = messageType;
            this.Priority = messagePriority;
            this.Topic = topic;
            this.Sender = SenderUser;
            this.Receiver = RecieverUser;
            this.Attachments = attachments;
            this.GetMessage(content);
        }
    }
}
