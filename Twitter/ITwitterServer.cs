using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Contracts;

namespace Twitter
{
    public interface ITwitterServer : IDisposable
    {
        void Start();
        ServerStatus Status { get; }
        ITwitterListener TwitterListener { get; }
    }
}
