using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Contracts
{
    public interface ILogger
    {
        void LogMessage(string message);
        void LogException(string message, Exception exception);
    }
}
