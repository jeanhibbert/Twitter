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
        ConcurrentDictionary<string, ITwitterClientService> TwitterClients
        {
            get;
        }
        void Post(ITwitterClientService twitterClient);
        void Wall(ITwitterClientService twitterClient);
    }
}
