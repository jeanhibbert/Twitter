using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Contracts.Services
{
    public class TwitterHandler : ITwitterHandler
    {

        private readonly ConcurrentDictionary<string, ITwitterClientService> _twitterClients = new ConcurrentDictionary<string, ITwitterClientService>();

        public TwitterHandler()
        {

        }

        public ConcurrentDictionary<string, ITwitterClientService> TwitterClients
        {
            get { return _twitterClients; }
        }

        public void Post(ITwitterClientService twitterClient)
        {
            throw new NotImplementedException();
        }

        public void Wall(ITwitterClientService twitterClient)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            foreach (ITwitterClientService twitterClient in _twitterClients.Values)
            {
                twitterClient.Dispose();
            }
        }
    }
}
