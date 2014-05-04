using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpUtils;
using Twitter.Contracts;
using TwitterTcpServerConsole.Services;

namespace Twitter.Tests
{
    [TestClass]
    public class TwitterListenerTestFixture
    {
        [TestMethod]
        public void CanListenForTwitterClients()
        {
            using (ITwitterListener twitterListener = new TwitterTcpListener(new TcpEndPointDetails()))
            {
                Assert.IsTrue(twitterListener.TwitterClients.Count == 0);
                twitterListener.Start();
            }
        }
    }
}
