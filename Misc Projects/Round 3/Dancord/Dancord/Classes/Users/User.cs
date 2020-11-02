using Dancord.Classes.Servers;

namespace Dancord.Classes.Users
{
    public class User
    {
        public class UserServers
        {
            public User User { get; }
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

        public User(string name, int id)
        {
            this.Name = name;
            this.ID = id;
            this.Servers = new UserServers(this);
        }
    }
}
