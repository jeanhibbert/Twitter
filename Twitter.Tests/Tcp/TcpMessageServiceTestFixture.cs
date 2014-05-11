using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TcpUtils;

namespace Twitter.Tests.Tcp
{
    [TestClass]
    public class TcpMessageServiceTestFixture
    {
        [TestMethod]
        public void CanRecieveMessagesFromExternalSource()
        {
            TcpMessageService tcpMessageService = new TcpMessageService(null, null);
            List<string> messages = new List<string>();
            tcpMessageService.MessageRecieved("hello");
            tcpMessageService.OnMessageRecieved.Subscribe(message => messages.Add(message));
            tcpMessageService.MessageRecieved("hello");
            Assert.IsTrue(messages.Count == 1);
        }

    }
}
