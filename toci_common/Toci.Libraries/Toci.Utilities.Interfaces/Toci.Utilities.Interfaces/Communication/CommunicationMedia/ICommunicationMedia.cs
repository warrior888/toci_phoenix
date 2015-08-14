namespace Toci.Utilities.Interfaces.Communication.CommunicationMedia
{
    public interface ICommunicationMedia
    {
        bool Send(IMessage message);

        //MessageMediaType MediumType { get; }

        CommunicationMediaPriority MediumPriority { get; }
    }
}