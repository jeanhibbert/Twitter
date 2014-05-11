using System;
using System.IO;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Threading;
using Twitter.Contracts;
using System.Reflection;

namespace TcpUtils
{
    public class TcpMessageService : ITwitterMessageService
    {
        private readonly TcpClient _client;
        private NetworkStream _networkStream;
        private StreamReader _reader;
        private StreamWriter _writer;
        private readonly ISubject<string> _stream = new Subject<string>();
        private Guid _sessionId = Guid.NewGuid();
        private Thread _thread;
       
        private readonly ILogger _logger;

        public TcpMessageService(TcpClient tcpClient, ILogger logger)
        {
            this._client = tcpClient;
            _logger = logger;
        }

        public TcpMessageService(int port, string host, ILogger logger)
        {
            this._client = new TcpClient(host, port);
            _logger = logger;
        }

        #region ITwitterClientService Members

        public Guid SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }

        public void Start()
        {
            _logger.LogMessage("Starting client session ..." + SessionId);
            _thread = new Thread(new ThreadStart(this.Run));
            this._networkStream = this._client.GetStream();
            this._reader = new StreamReader(this._networkStream);
            this._writer = new StreamWriter(this._networkStream);
            _thread.Start();
        }

        private void Run()
        {
            try
            {
                string message = null;
                using (this._reader)
                {
                    do
                    {

                        message = _reader.ReadLine();
                        MessageRecieved(message);
                    }
                    while (!String.IsNullOrEmpty(message));
                }
            }
            catch (IOException io)
            {
                _logger.LogMessage(MethodBase.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name +
                    "; IOException: " + io.ToString());
            }
            _thread.Join();
        }

        public void MessageRecieved(string message)
        {
            this._stream.OnNext(message);
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
            _logger.LogMessage(SessionId + " sending : " + message);
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
