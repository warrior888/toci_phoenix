
using Toci.Utilities.Abstraction.Communication;
using Toci.Utilities.Interfaces.Communication;

namespace Toci.Utilities.Communication.MessageTypes
{
    public class ShortNotification : Message
    {
        public ShortNotification() 
        {
           this.MessageType = MessageType.ShortNotification;
          
        }

    }

}
