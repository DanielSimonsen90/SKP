using Dancord.Classes.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Dancord.Classes.Channels
{
    class ChannelManager 
    {
        public BasicList<Channel> Channels = new BasicList<Channel>();

        public event OnDelete<Channel> OnDeleted;

        public void Create(string name)
        {
            TextChannel channel = new TextChannel(name);
            Channels.Add(channel);
        }
    }
}
