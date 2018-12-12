using FicheUtilities.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicheUtilities.CLI
{
    public static class ConsoleWriter
    {
        public static void WriteLine(MessageType messageType, string message)
        {
            switch (messageType)
            {
                case MessageType.Info:
                    WriteInfo(message);
                    break;
                case MessageType.Ok:
                    WriteOK(message);
                    break;
                case MessageType.Warning:
                    WriteWarning(message);
                    break;
                case MessageType.Critical:
                    WriteCritical(message);
                    break;
                default:
                    break;
            }
        }

        private static void WriteInfo(string message)
        {
            Console.WriteLine(message);
        }

        private static void WriteOK(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void WriteWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void WriteCritical(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
