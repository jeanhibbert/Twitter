using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpUtils;
using Twitter;
using TwitterTcpServerConsole.Services;

namespace TwitterTcpServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Server...");
            using (ITwitterServer twitterServer = new TwitterTcpServer(
                new TcpEndPointDetails { IpAddress = "127.0.0.1", Port = 10101 }))
            {
                twitterServer.Start();
                Console.WriteLine("Server started.");
                Console.WriteLine("Type 'exit' to stop server.");
                string line = null;
                while ((line = Console.ReadLine()) != null)
                {
                    if (line.ToLowerInvariant().Equals("exit"))
                    {
                        break;
                    }
                }
                Console.WriteLine("Stopping Server...");
            }
            Console.WriteLine("Server stopped.");
        }
    }
}
