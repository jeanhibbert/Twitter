using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpUtils;
using Twitter.Contracts;
using Twitter.Services;
using TwitterTcpServerConsole.Services;

namespace Twitter.Tests
{
    [TestClass]
    public class TwitterListenerTestFixture
    {
        [TestMethod]
        public void CanListenForTwitterClients()
        {
            ITwitterListener twitterListener = new TwitterTcpListener(null, new TwitterHandler(), new ConsoleLogger());
            Assert.IsNotNull(twitterListener);
        }
    }
}
