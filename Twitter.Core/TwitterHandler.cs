using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using Twitter.Contracts;
using Twitter.Model;

namespace Twitter.Services
{
    public class TwitterHandler : ITwitterHandler
    {

        private readonly ConcurrentBag<ITwitterMessageService> _twitterClients = new ConcurrentBag<ITwitterMessageService>();
        private readonly TwitterCommandService _twitterCommandService = new TwitterCommandService();
        private readonly CompositeDisposable _compositeDisposable = new CompositeDisposable();

        public TwitterHandler()
        {

        }

        public ConcurrentBag<ITwitterMessageService> TwitterClients
        {
            get { return _twitterClients; }
        }
        
        public void Add(ITwitterMessageService twitterClientService)
        {
            _twitterClients.Add(twitterClientService);
            _compositeDisposable.Add(twitterClientService.OnMessageRecieved.Subscribe(message => 
            {
                MessageReceivedFromClient(twitterClientService, message);
            }));
        }

        private void MessageReceivedFromClient(ITwitterMessageService twitterClientService, string message)
        {
            TwitterCommand command = _twitterCommandService.GetCommand(message);
            command.TwitterClient = new TwitterClient() { Name = twitterClientService.SessionId.ToString() }; // TO COMPLETE
            if (command.TwitterCommandType == TwitterCommandType.Post)
            {
                // Post on the client that posted the messages wall and post on all the follower's walls
                twitterClientService.Send(command.ToString());
            }
        }


        public void Dispose()
        {
            _compositeDisposable.Dispose();
            foreach (ITwitterMessageService twitterClient in _twitterClients)
            {
                twitterClient.Dispose();
            }
        }
    }
}
