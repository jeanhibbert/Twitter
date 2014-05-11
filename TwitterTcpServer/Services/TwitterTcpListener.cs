using System;
using System.Net;
using System.Net.Sockets;
using TcpUtils;
using Twitter.Contracts;

namespace TwitterTcpServerConsole.Services
{
    public class TwitterTcpListener : ITwitterListener
    {
        private readonly ITwitterHandler _twitterHandler;
        private readonly TcpEndPointDetails _tcpEndpointDetails;
        private readonly ILogger _logger;

        private ListenerStatus _listenerStatus = ListenerStatus.Stopped;
        private TcpListener _tcpListener;

        public TwitterTcpListener(TcpEndPointDetails tcpEndpointDetails, ITwitterHandler twitterHandler, ILogger logger)
        {
            _tcpEndpointDetails = tcpEndpointDetails;
            _twitterHandler = twitterHandler;
            _logger = logger;
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
                    ITwitterMessageService twitterClient = new TcpMessageService(tcpClient, _logger);
                    _twitterHandler.Add(twitterClient);
                    twitterClient.Start();
                    _logger.LogMessage("Listener added new Tcp Client : " + twitterClient.SessionId);
                }
                _listenerStatus = ListenerStatus.Started;
            }
            catch (SocketException ex)
            {
                _logger.LogException("Start - Listener: ", ex);
            }
        }

        public void Dispose()
        {
            if (_tcpListener != null)
            {
                _twitterHandler.Dispose();
                _tcpListener.Stop();
            }
            _listenerStatus = ListenerStatus.Stopped;
        }

        public ListenerStatus Status
        {
            get { return _listenerStatus; }
        }
    }
}
