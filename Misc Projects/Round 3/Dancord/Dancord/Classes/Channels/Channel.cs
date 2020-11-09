using Dancord.Classes.Base;

namespace Dancord.Classes.Channels
{
    public abstract class Channel : IJSONID
    {
        public Name Name { get; private set; }
        public int ID { get; }
        public event OnDelete<Channel> OnDeleting;

        public Channel(string name, int ID)
        {
            this.Name = new Name(name);
            this.ID = ID;
        }

        public void Delete() => OnDeleting(this);

        public string ToJSON(bool onlyID) => 
            "{" +
                (onlyID ? "" : $"Name: {Name.ToJSON()}") +
                $"ID: {ID}" +
            "}";
    }
}
