using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twitter.Contracts;
using TcpUtils;
using TwitterTcpServerConsole.Services;
using Twitter.Services;
using System.Collections.Generic;

namespace Twitter.Tests.Tcp
{
    [TestClass]
    public class TwitterHandlerTestFixture
    {
        [TestMethod]
        public void CanReceiveMessagesFromSubscribedClients()
        {
            ITwitterMessageService twitterMessageService = new TcpMessageService(null, null);
            
            ITwitterHandler twitterHandler = new TwitterHandler();
            twitterHandler.Add(twitterMessageService);
            
            List<string> messages = new List<string>();
            twitterMessageService.OnMessageRecieved.Subscribe(message => messages.Add(message));

            twitterMessageService.MessageRecieved("is there somebody out there?");

            Assert.IsTrue(messages.Count == 1);

        }
    }
}
