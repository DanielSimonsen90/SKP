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
        private readonly BasicList<Channel> Channels = new BasicList<Channel>();

        public void Create(string name)
        {
            TextChannel channel = new TextChannel(name);
            channel.OnDeleting += OnDeleted;
            Channels.Add(channel);
        }

        private void OnDeleted(Channel channel) => Channels.Remove(channel);
    }
}
