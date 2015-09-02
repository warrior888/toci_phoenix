using System.IO;

namespace Toci.Utilities.Interfaces.Communication.CommunicationMessages
{
    public interface IMessageAttachment
    {
        MessageAttachmentType AttachmentType { get; }
        string AttachmentName { get; }
        bool IsSupported(MessageMediaType mediaType, MessageAttachmentType attachmentType,double attachmentSize);
        Stream AttachmentStream { get; }

        Stream GetAttachment();
    }
}