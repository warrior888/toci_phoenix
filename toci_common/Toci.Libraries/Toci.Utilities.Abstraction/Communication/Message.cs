
using System.Collections.Generic;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMessages;
using Toci.Utilities.Interfaces.User;

namespace Toci.Utilities.Abstraction.Communication
{
    public abstract class Message : IMessage, IMessageTemplate
    {
        public MessageMediaType MessageMediaType { get; set; }
        public MessageType MessageType { get; set; }
        public MessagePriority Priority { get; set; }
        public IUser Sender { get; set; }
        public IUser Receiver { get; set; }
        public string Topic { get; set; }
     
        public Dictionary<MessageAttachmentType, List<IMessageAttachment>> Attachments { get; set; }
        
        public string GetMessage(params string[] messageContent)
        {
            return string.Empty;
        }

        public string GetTemplate(MessageMediaType mediaType, MessageType messageType)
        {
          
            return null;
        }
    }
}
