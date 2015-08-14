using Toci.Utilities.Abstraction.Communication;
using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMedia;

namespace Toci.Utilities.Communication.MediaTypes
{
    public class Sms : CommunicationMedia
    {
        public  Sms()
        {
            //this.MediumType = MessageMediaType.Sms;
            this.MediumPriority = CommunicationMediaPriority.High;
            
        }

        public override bool Send(IMessage message)
        {
            return true;
        }
    }
}
