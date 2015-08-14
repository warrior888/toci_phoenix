using Toci.Utilities.Interfaces.Communication;
using Toci.Utilities.Interfaces.Communication.CommunicationMedia;

namespace Toci.Utilities.Abstraction.Communication
{
    public abstract class CommunicationMedia : ICommunicationMedia
    {
        public abstract bool Send(IMessage message);
        //public MessageMediaType MediumType { get; protected set; }
        public CommunicationMediaPriority MediumPriority { get; protected set; }
    }
}
