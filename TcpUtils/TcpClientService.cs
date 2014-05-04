using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpUtils
{
    public class TcpClientService : IDisposable
    {
        private readonly TcpClient _client;
        private NetworkStream _networkStream;
        private StreamReader _reader;
        private StreamWriter _writer;
        private ISubject<string> _stream;

        public TcpClientService(TcpClient tcpClient)
        {
            this._client = tcpClient;
        }

        public TcpClientService(int port, string host)
        {
            this._client = new TcpClient(host, port);
        }

        #region IMessagingService Members

        public void Start()
        {
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
