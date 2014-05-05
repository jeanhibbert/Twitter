using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Twitter.Contracts;

namespace TcpUtils
{
    public class TcpClientService : ITwitterClientService
    {
        private readonly TcpClient _client;
        private NetworkStream _networkStream;
        private StreamReader _reader;
        private StreamWriter _writer;
        private ISubject<string> _stream = new Subject<string>();
        private string _Name = Guid.NewGuid().ToString();

        private readonly ILogger _logger;

        public TcpClientService(TcpClient tcpClient, ILogger logger)
        {
            this._client = tcpClient;
            _logger = logger;
        }

        public TcpClientService(int port, string host, ILogger logger)
        {
            this._client = new TcpClient(host, port);
            _logger = logger;
        }

        #region ITwitterClientService Members

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public void Start()
        {
            _logger.LogMessage(_Name + " starting...");
            this._stream = new Subject<string>();
            Thread thread = new Thread(new ThreadStart(this.Run));
            this._networkStream = this._client.GetStream();
            this._reader = new StreamReader(this._networkStream);
            this._writer = new StreamWriter(this._networkStream);
            thread.Start();
        }

        private void Run()
        {
            String line = null;
            while ((line = this._reader.ReadLine()) != null)
            {
                _logger.LogMessage(_Name + " recieved : " + line);
                this._stream.OnNext(line);
            }
        }

        public IObservable<string> OnMessageRecieved
        {
            get
            {
                return _stream;
            }
        }

        public void Send(string message)
        {
            _logger.LogMessage(_Name + " sending : " + message);
            this._writer.WriteLine(message);
            this._writer.Flush();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this._reader.Close();
            this._writer.Close();
            this._networkStream.Close();
        }

        #endregion
    }
}
