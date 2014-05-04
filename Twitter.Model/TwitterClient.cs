using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Model
{
    public class TwitterClient
    {
        public long TwitterClientId { get; set; }
        public string Name { get; set; }
        public virtual IList<TwitterCommand> TwitterCommands { get; set; }
    }
}
