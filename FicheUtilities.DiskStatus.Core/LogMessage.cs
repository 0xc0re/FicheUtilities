using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicheUtilities.DiskStatus.Core
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
