using System.IO;
using Toci.Utilities.Abstraction.Communication;
using Toci.Utilities.Abstraction.Communication.Factories;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMessages;

namespace Toci.Utilities.Communication
{
    public class EmailMessageAttachment : MessageAttachment
    {
      
 
        public EmailMessageAttachment(string path): base(path)
        {

        }
 
    }
}
