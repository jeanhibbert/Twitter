using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter;
using Twitter.Contracts;

namespace TwitterTcpServerConsole.Services
{
    public class TwitterTcpServer : ITwitterServer
    {
        private TcpUtils.TcpEndPointDetails tcpEndPointDetails;

        public TwitterTcpServer(TcpUtils.TcpEndPointDetails tcpEndPointDetails)
        {
            // TODO: Complete member initialization
            this.tcpEndPointDetails = tcpEndPointDetails;
        }
        public void Start()
        {
            throw new NotImplementedException();
        }

        public ServerStatus Status
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ITwitterListener TwitterListener
        {
            get { throw new NotImplementedException(); }
        }
    }
}
