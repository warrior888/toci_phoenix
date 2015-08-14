using System;
using System.Collections.Generic;
using System.Linq;
using Toci.Utilities.Abstraction.DesignPatterns;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMessages;

namespace Toci.Utilities.Abstraction.Communication.Factories
{
    public class SupportedAttachmentsFactory : Factory<MessageMediaType, List<MessageAttachmentType>>
    {
        public SupportedAttachmentsFactory()
        {
            this.FactoryDictionary = new Dictionary<MessageMediaType, Func<List<MessageAttachmentType>>>
            {
                {MessageMediaType.Email, ()=>Enum.GetValues(typeof(MessageAttachmentType)).Cast<MessageAttachmentType>().ToList()},//all types in enum
                {MessageMediaType.Mms, ()=>new List<MessageAttachmentType>(){MessageAttachmentType.Photo,MessageAttachmentType.Video,MessageAttachmentType.Sound}},
                {MessageMediaType.FacebookMessage, ()=>Enum.GetValues(typeof(MessageAttachmentType)).Cast<MessageAttachmentType>().ToList()},
             
            };
        }
    }
}
