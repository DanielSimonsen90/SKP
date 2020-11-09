using Dancord.Classes.Base;
using Dancord.Classes.Users;

namespace Dancord.Classes.Servers
{
    public class ServersManager : IJSONID
    {
        private User User { get; }
        public BasicList<Server> Servers = new BasicList<Server>();

        public ServersManager(User user) => this.User = user;

        public void Create(string name) => Servers.Add(new Server(name, this.User));
        public void Delete(Server server) => Servers.Remove(server);

        public string ToJSON() =>
            "{" +
                $"User: {User.ToJSON(true)}" +
                $"Servers: {Servers.ToJSON()}" +
            "}";
    }
}
