using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TcpUtils;
using Twitter;
using Twitter.Contracts;

namespace TwitterTcpServerConsole.Services
{
    public class TwitterTcpServer : ITwitterServer
    {
        private readonly TcpEndPointDetails _tcpEndPointDetails;
        private readonly ITwitterListener _twitterListener;
        
        private ServerStatus _serverStatus = ServerStatus.Stopped;
        private Thread _thread;

        public TwitterTcpServer(TcpEndPointDetails tcpEndPointDetails, ITwitterListener twitterListener)
        {
            _tcpEndPointDetails = tcpEndPointDetails;
            _twitterListener = twitterListener;
        }

        public void Start()
        {
            _thread = new Thread(_twitterListener.Start);
            _thread.Start();
            _serverStatus = ServerStatus.Started;
        }

        public ServerStatus Status
        {
            get { return _serverStatus; }
        }

        public void Dispose()
        {
            _twitterListener.Dispose();
            _serverStatus = ServerStatus.Stopped;
            _thread.Join();
        }

        public ITwitterListener TwitterListener
        {
            get { return _twitterListener; }
        }
    }
}
