using Dancord.Classes.Base;

namespace Dancord.Classes.Channels
{
    public class ChannelManager : IJSON
    {
        private readonly BasicList<Channel> Channels = new BasicList<Channel>();

        public void Create(string name)
        {
            TextChannel channel = new TextChannel(name, Channels.Count);
            channel.OnDeleting += OnDeleted;
            Channels.Add(channel);
        }
        private void OnDeleted(Channel channel) => Channels.Remove(channel);

        public string ToJSON() =>
            "{" +
                $"Channels: {Channels.ToJSON()}" +
            "}";
    }
}