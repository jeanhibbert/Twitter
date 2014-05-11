using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Contracts
{
    public interface ITwitterHandler : IDisposable
    {
        ConcurrentBag<ITwitterMessageService> TwitterClients { get; }
        void Add(ITwitterMessageService twitterClientService);
    }
}
