using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpUtils;
using Twitter.Model;
using Twitter.Model.Contracts;

namespace TwitterTcpServerConsole.Services
{
    public class TwitterTcpClient : ITwitterClient
    {
        private readonly TwitterTcpListener _twitterTcpListener;
        private readonly TcpClientService _tcpClientService;

        public TwitterTcpClient(TwitterTcpListener twitterTcpListener, TcpClientService tcpClientService)
        {
            this._twitterTcpListener = twitterTcpListener;
            this._tcpClientService = tcpClientService;
            this.Name = new Guid().ToString();
        }

        public void Start()
        {
            //_tcpClientService.OnMessageRecieved.Subscribe()
        }

        public string Name { get; set; }

        public bool Connected { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
