namespace FicheUtilities.Storage
{
    public class LogMessage
    {
        public string Message { get; private set; }
        public MessageType MessageType { get; private set; }

        public LogMessage(string message, MessageType messageType)
        {
            Message = message;
            MessageType = messageType;
        }
    }
}
