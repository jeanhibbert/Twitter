using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.Contracts;
using TwitterTcpServerConsole.Services;
using TcpUtils;

namespace Twitter.Tests
{
    [TestClass]
    public class TwitterServerTestFixture
    {
        [TestMethod]
        public void CanStartTwitterServer()
        {
            using (ITwitterServer twitterServer = new TwitterTcpServer(new TcpEndPointDetails()))
            {
                Assert.AreEqual(twitterServer.Status, ServerStatus.Stopped);
                twitterServer.Start();
                Assert.AreEqual(twitterServer.Status, ServerStatus.Started);
                Assert.IsNotNull(twitterServer.TwitterListener);
                Assert.AreEqual(twitterServer.TwitterListener.Status, ListenerStatus.Started);
            }
        }
    }
}
