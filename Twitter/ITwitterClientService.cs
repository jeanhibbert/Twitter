using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Contracts
{
    public interface ITwitterClientService : IDisposable
    {
        void Start();
        IObservable<string> OnMessageRecieved {get;}
        void Send(string message);
        string Name { get; set; }
    }
}
