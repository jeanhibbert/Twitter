using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitter.Contracts;
using Twitter.Model;
using Twitter.Model.Contracts;

namespace Twitter.Contracts
{
    public interface ITwitterListener : IDisposable
    {
        IDictionary<string, ITwitterClient> TwitterClients
        {
            get;
        }
        void Start();
        ListenerStatus Status { get; }
    }
}
