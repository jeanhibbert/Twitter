using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpUtils;
using Twitter.Contracts;
using Twitter.Model;
using Twitter.Model.Contracts;

namespace TwitterTcpServerConsole.Services
{
    public class TwitterTcpListener : ITwitterListener
    {

        private readonly ConcurrentDictionary<string, ITwitterClient> _twitterClients = new ConcurrentDictionary<string, ITwitterClient>();
        private readonly TcpEndPointDetails _tcpEndpointDetails;
        private TcpListener _tcpListener;

        public TwitterTcpListener(TcpEndPointDetails tcpEndpointDetails)
        {
            _tcpEndpointDetails = tcpEndpointDetails;
        }

        public IDictionary<string, ITwitterClient> TwitterClients
        {
            get { return _twitterClients; }
        }

        public void Start()
        {
            _tcpListener = new TcpListener(IPAddress.Parse(_tcpEndpointDetails.IpAddress), _tcpEndpointDetails.Port);
            _tcpListener.Start();
            try
            {
                TcpClient tcpClient = null;
                while ((tcpClient = _tcpListener.AcceptTcpClient()) != null)
                {
                    ITwitterClient twitterClient = new TwitterTcpClient(this, new TcpClientService(tcpClient));
                    //_twitterClients.AddOrUpdate(twitterClient.Name, twitterClient, (x.Name, x) => x);
                    twitterClient.Start();
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            if (_tcpListener != null)
            {
                _tcpListener.Stop();
            }
        }

        public ListenerStatus Status
        {
            get { throw new NotImplementedException(); }
        }
    }
}
