using Dancord.Classes.Base;

namespace Dancord.Classes.Channels
{
    public abstract class Channel : IJSONID
    {
        public Name Name { get; private set; }
        public event OnDelete<Channel> OnDeleting;

        public Channel(string name)
        {
            this.Name = new Name(name);
        }

        public void Delete() => OnDeleting(this);

        public string ToJSON() =>
            "{" +
                $"Name: {Name.ToJSON()}" +
            "}";
    }
}
