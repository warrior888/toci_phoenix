using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Utilities.Abstraction.Communication;
using Toci.Utilities.Abstraction.Communication.Factories;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMessages;

namespace _3mb.Integration.Test.Developers.Dysq.SupportedAttachments
{
    public class DocAttachment : MessageAttachment
    {
        public DocAttachment(string path) : base(path)
        {
            //this.AttachmentType = MessageAttachmentType.Doc;
            //this.MaxAttachmentSize = maxAttachmentSize;
        }
   
    }

    public class VideoAttachment : MessageAttachment
    {
        public VideoAttachment(string path): base(path) 
        {
            //this.AttachmentType = MessageAttachmentType.Video;
            //this.MaxAttachmentSize = maxAttachmentSize;
        }

   
    }

    [TestClass]
    public class SupportedAttachmentsTest
    {
        [TestMethod]
        public void SupportedAttachmentsDysqTest()
        {
            //var doc = new DocAttachment();
            var path = @"D:\lawd.jpg";
 
            var video = new VideoAttachment(path);

            //****************DOC TEST******************************/
           // Assert.IsFalse(doc.IsSupported(MessageMediaType.Sms, doc.AttachmentType, 1000000000));
           // Assert.IsTrue(doc.IsSupported(MessageMediaType.FacebookMessage, doc.AttachmentType, 1000000));
            //************************** VIDEO TEST ********************************/
           // Assert.IsFalse(video.IsSupported(MessageMediaType.Fax, video.AttachmentType, 100000));
            Assert.IsTrue(video.IsSupported(MessageMediaType.Mms, video.AttachmentType, 100000));
           // Assert.IsTrue(video.IsSupported(MessageMediaType.JabberMessage, video.AttachmentType, 1000000));
            Assert.IsFalse(video.IsSupported(MessageMediaType.Sms, video.AttachmentType, 1000000));
            Assert.IsTrue(video.IsSupported(MessageMediaType.Email, video.AttachmentType, 1000000));

        }
    }
}
