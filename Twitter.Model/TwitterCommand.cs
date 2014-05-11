using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Model
{
    public class TwitterCommand
    {
        public long TwitterCommandId { get; set; }
        public TwitterCommandType TwitterCommandType { get; set; }
        public string Message { get; set; }
        public virtual TwitterClient TwitterClient {get; set;}

        public override string ToString()
        {
            return DateTime.Now.ToString() + ":" + TwitterClient.Name + " -> " + Message;
        }
    }
}
