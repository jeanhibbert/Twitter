using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpUtils;
using Twitter.Contracts;

namespace TwitterTcpClientConsole.Services
{
    public class TwitterTcpClientConnection : ITwitterClientConnection
    {
        private readonly TcpClientService _tcpClientService;

        public TwitterTcpClientConnection(string host, int ipAddress)
        {
            _tcpClientService = new TcpClientService(ipAddress, host);
        }
        
        public void Open()
        {
            _tcpClientService.Start();
        }

        public IObservable<string> OnMessageRecieved
        {
            get { return _tcpClientService.OnMessageRecieved; }
        }

        public void Dispose()
        {
            _tcpClientService.Dispose();
        }

        public void Send(string message)
        {
            _tcpClientService.Send(message);
        }
    }
}
