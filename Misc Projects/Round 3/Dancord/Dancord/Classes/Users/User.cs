using Dancord.Classes.Base;
using Dancord.Classes.Servers;
using System.Text;
using System.Windows.Media.Animation;

namespace Dancord.Classes.Users
{
    public class User : IJSON
    {
        public class UserServers : IJSON
        {
            private User User { get; }
            public ServersManager All;
            public ServersManager Own;

            public UserServers(User user)
            {
                this.User = user;
                this.Own = new ServersManager(this.User);
                this.All = new ServersManager(this.User);
                this.All.Create("Dancord Official");
            }

            public string ToJSON(bool onlyID) =>
                "{" +
                    $"UserID: {User.ID}" +
                    $"All: {All.ToJSON()}" +
                    $"Own: {Own.ToJSON()}" +
                "}";

            
        }

        public Name Name { get; }
        public int ID { get; }

        public UserServers Servers;
        private readonly BasicList<User> Friends = new BasicList<User>();
        public void AddFriend(User user) => Friends.Add(user);
        public void RemoveFriend(User user) => Friends.Remove(user);

        private readonly BasicList<User> Blocked = new BasicList<User>();
        public void Block(User user)
        {
            if (Friends.Contains(user)) RemoveFriend(user);
            Blocked.Add(user);
        }
        public void Unblock(User user) => Blocked.Remove(user);

        public User(string name, int id)
        {
            this.Name = new Name(name);
            this.ID = id;
            this.Servers = new UserServers(this);
        }

        public string ToJSON(bool onlyID)
        {
            StringBuilder result = new StringBuilder();
            result.Append(
                "{" +
                    $"Name: {Name.ToJSON()}" +
                    $"ID: {ID}"
                );
            if (!onlyID) result.Append(
                 $"Servers: {Servers.ToJSON(true)}" +
                 $"Friends: {Friends.ToJSON(true)}" +
                 $"Blocked: {Blocked.ToJSON(true)}"
                 );
            return result.ToString() + "}";
        }
    }
}
