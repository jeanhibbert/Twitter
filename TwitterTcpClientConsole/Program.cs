using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Contracts;
using TwitterTcpClientConsole.Services;

namespace TwitterTcpClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Opening connection...");
            using (ITwitterClientConnection connection = new TwitterTcpClientConnection("localhost", 10101))
            {
                connection.OnMessageRecieved.Subscribe(ReceiveMessage);
                connection.Open();
                Console.WriteLine("Connection opened.");
                Console.WriteLine("Type 'exit' to close connection.");

                string line = null;
                while ((line = Console.ReadLine()) != null)
                {
                    if (line.ToLowerInvariant().Equals("exit"))
                    {
                        break;
                    }
                    else
                    {
                        connection.Send(line);
                    }
                }
            }
            Console.WriteLine("Closing connection...");
        }
        public static void ReceiveMessage(string message)
        {
            Console.WriteLine(message + Environment.NewLine);
        }
    }
}
