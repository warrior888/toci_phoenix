using System;
using System.IO;
using Toci.Utilities.Abstraction.Communication.Factories;
using Toci.Utilities.Interfaces;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMessages;

namespace Toci.Utilities.Abstraction.Communication
{
    public abstract class MessageAttachment : IMessageAttachment, IDocumentResource
    {
        public MessageAttachmentType AttachmentType { get; protected set; }
        public string AttachmentName { get; private set; }
        public Stream AttachmentStream { get; protected set; }

        private const char PathSlash = '\\';
        private const char Dot = '.';
        private const int StartPositionShift = 1;


        protected MessageAttachment(string path)
        {

            if (!File.Exists(path)) throw new FileNotFoundException();

            this.AttachmentStream = Open(path);
            this.AttachmentType = new AttachmentTypeFactory().Create(Path.GetExtension(path).ToUpperInvariant().Remove(0,1)); //removes "." dot, at the begginning

            this.AttachmentName = GetAttachmentNameFromPath(path);
        }

        public bool IsSupported(MessageMediaType mediaType, MessageAttachmentType attachmentType,double attachmentSize)
        {
   
            return new SupportedAttachmentsFactory().Create(MessageMediaType.Email).Contains(MessageAttachmentType.Photo)
                   && attachmentSize <= new AttachmentSizeFactory().Create(mediaType);
        }


        public Stream Open(string path)
        {
            return new FileStream(path, FileMode.Open);
        }

        public Stream GetAttachment()
        {
            if (IsSupported(MessageMediaType.Email, AttachmentType, AttachmentStream.Length))
            {
               
                return AttachmentStream;

            }
           throw new NotSupportedException();
        }

        protected string GetAttachmentNameFromPath(string path)
        {
            var substringStartPostion = path.LastIndexOf(PathSlash) + StartPositionShift;
            var substringEndPostition = path.LastIndexOf(Dot);
            return path.Substring(substringStartPostion, substringEndPostition - substringStartPostion);
        }
    }
}
