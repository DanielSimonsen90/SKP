using Dancord.Classes.Base;
using Dancord.Classes.Servers;

namespace Dancord.Classes.Users
{
    public class User
    {
        public class UserServers
        {
            private User User { get; }
            public ServersManager All;
            public ServersManager Own;

            public UserServers(User user)
            {
                this.User = user;
                this.Own = new ServersManager(this.User);
                this.All = new ServersManager(this.User);
            }
        }

        public string Name { get; }
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
            this.Name = name;
            this.ID = id;
            this.Servers = new UserServers(this);
        }

    }
}
