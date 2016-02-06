using System;

namespace Toci.Utilities.Interfaces.Communication.CommunicationMedia
{
    [Flags]
    public enum CommunicationMediaPriority
    {
        High, // 1
        Medium, //2
        Low //4

        // 1 1 1

        //   0 0 1
        //   0 1 0
        //   1 0 0
        // 1 0 0 0
    }
}