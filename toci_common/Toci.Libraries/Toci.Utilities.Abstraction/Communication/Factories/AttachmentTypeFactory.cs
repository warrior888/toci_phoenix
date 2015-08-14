using System;
using System.Collections.Generic;
using Toci.Utilities.Abstraction.DesignPatterns;
using Toci.Utilities.Interfaces.Communication.CommunicationMessages;

namespace Toci.Utilities.Abstraction.Communication.Factories
{
    public class AttachmentTypeFactory : Factory<string, MessageAttachmentType>
    {
        public AttachmentTypeFactory()
        {
            FactoryDictionary = new Dictionary<string, Func<MessageAttachmentType>>()
            {
                {"DOC",()=>MessageAttachmentType.Doc},
                {"DOCX",()=>MessageAttachmentType.Doc},

                {"MP3",()=>MessageAttachmentType.Sound},
                {"WAV",()=>MessageAttachmentType.Sound},

                {"JPG",()=>MessageAttachmentType.Photo},
                {"PNG",()=>MessageAttachmentType.Photo},
                {"GIF",()=>MessageAttachmentType.Photo},

                {"AVI",()=>MessageAttachmentType.Video},
            };
        }
    }
}
