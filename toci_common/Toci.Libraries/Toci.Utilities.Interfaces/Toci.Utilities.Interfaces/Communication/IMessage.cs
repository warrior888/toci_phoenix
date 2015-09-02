using System.Collections.Generic;
using Toci.Utilities.Interfaces.Communication.CommunicationMessages;
using Toci.Utilities.Interfaces.User;

namespace Toci.Utilities.Interfaces.Communication
{
    public interface IMessage
    {
        string Topic { get; }

        MessageType MessageType { get; }

        MessageMediaType MessageMediaType { get; }

        Dictionary<MessageAttachmentType, List<IMessageAttachment>> Attachments { get; }

        string GetMessage(params string[] messageContent);

        MessagePriority Priority {get;}

        IUser Sender { get; }

        IUser Receiver { get; }

        //bool IsValid();
    }
}