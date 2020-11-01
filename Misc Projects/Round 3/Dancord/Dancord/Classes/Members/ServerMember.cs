using Dancord.Classes.Roles;
using Dancord.Classes.Users;
using System;
using System.Dynamic;

namespace Dancord.Classes.Members
{
    public class ServerMember
    {
        public delegate void OnLeave(ServerMember member);
        public OnLeave OnLeaving;

        private User User { get; set; }
        public string Nickname { get => nickname; set => throw new NotImplementedException(); }
        private string nickname;
        public DateTime JoinedAt { get; private set; }
        public RoleManager Roles { get; }
        public bool IsOwner;


        public ServerMember(User user)
        {
            this.User = user;
            this.JoinedAt = DateTime.Now;
        }
        public ServerMember(User user, bool isOwner) : this(user) => this.IsOwner = isOwner;

        public override string ToString() => Nickname is null ? User.Name : Nickname;
    }
}