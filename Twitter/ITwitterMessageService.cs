using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Contracts
{
    public interface ITwitterMessageService : IDisposable
    {
        void Start();
        IObservable<string> OnMessageRecieved {get;}
        void Send(string message);
        Guid SessionId { get; set; }
        void MessageRecieved(string message);
    }
}
