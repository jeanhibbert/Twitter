using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Model.Contracts
{
    public interface ITwitterClient : IDisposable
    {
        void Start();
        string Name { get; set; }
        bool Connected { get; set; }
    }
}
