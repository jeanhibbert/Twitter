using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Contracts;

namespace TcpUtils
{
    public class ConsoleLogger: ILogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void LogException(string message, Exception exception)
        {
            Console.WriteLine(message + " -- " + exception.Message);
        }
    }
}
