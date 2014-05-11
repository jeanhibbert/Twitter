using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twitter.Model;

namespace Twitter.Services
{
    public class TwitterCommandService
    {
        public TwitterCommand GetCommand(string message)
        {
            TwitterCommand twitterCommand = new TwitterCommand();
            twitterCommand.TwitterCommandType = TwitterCommandType.Post;
            twitterCommand.Message = message;
            return twitterCommand;
        }
    }
}
