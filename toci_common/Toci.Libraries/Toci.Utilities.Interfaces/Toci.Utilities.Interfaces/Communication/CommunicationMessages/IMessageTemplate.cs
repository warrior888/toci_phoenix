namespace Toci.Utilities.Interfaces.Communication.CommunicationMessages
{
    public interface IMessageTemplate
    {
        string GetTemplate(MessageMediaType mediaType, MessageType messageType);  // return pattern for message
    }
}