using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitter.Contracts;
using Twitter.Model;

namespace Twitter.Contracts
{
    public interface ITwitterListener : IDisposable
    {
        void Start();
        ListenerStatus Status { get; }
    }
}
