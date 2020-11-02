using Dancord.Classes.Base;

namespace Dancord.Classes.Channels
{
    public class ChannelManager
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
