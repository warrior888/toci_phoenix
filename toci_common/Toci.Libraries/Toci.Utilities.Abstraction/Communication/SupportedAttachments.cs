using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMessages;

namespace Toci.Utilities.Abstraction.Communication
{
    public class SupportedAttachments
    {
        public bool CheckSupportedAttachments(MessageMediaType mediaType, MessageAttachmentType attachmentType)
        {
           
            var listOfAllAttachments = new List<MessageAttachmentType>
            {
                MessageAttachmentType.Doc,
                MessageAttachmentType.Photo,
                MessageAttachmentType.Sound,
                MessageAttachmentType.Video,
            };
            var listOfAttachmentsForFaxAndSms = new List<MessageAttachmentType>
            {
                MessageAttachmentType.Doc,
            };
            var supportedAttachmentsByMedia = new Dictionary<MessageMediaType, List<MessageAttachmentType>>
               {
                   {MessageMediaType.Email,listOfAllAttachments },
                   {MessageMediaType.FacebookMessage,listOfAllAttachments},
                   {MessageMediaType.JabberMessage,listOfAllAttachments},
                   {MessageMediaType.Mms,listOfAllAttachments},
                   {MessageMediaType.Fax,listOfAttachmentsForFaxAndSms },
                   {MessageMediaType.Sms,listOfAttachmentsForFaxAndSms}
               };

            return 
                supportedAttachmentsByMedia.Where(item => item.Key.Equals(mediaType)).Any(item => item.Value.Contains(attachmentType));
        }

    }
}
