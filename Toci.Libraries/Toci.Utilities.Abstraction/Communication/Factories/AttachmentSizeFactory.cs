using System;
using System.Collections.Generic;
using Toci.Utilities.Abstraction.DesignPatterns;
using Toci.Utilities.Interfaces.Communication;

namespace Toci.Utilities.Abstraction.Communication.Factories
{
    public class AttachmentSizeFactory : Factory<MessageMediaType, int>
    {
        public AttachmentSizeFactory()
        {
            this.FactoryDictionary = new Dictionary<MessageMediaType, Func<int>>()
            {
                {MessageMediaType.Email, ()=>5000000},
                {MessageMediaType.Mms, ()=>500000},
                {MessageMediaType.FacebookMessage, ()=>5000000},
                {MessageMediaType.Sms, ()=>0},
            };
        }
    }
}
