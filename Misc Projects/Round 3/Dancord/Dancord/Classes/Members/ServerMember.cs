using Dancord.Classes.Base;
using Dancord.Classes.Roles;
using Dancord.Classes.Users;
using System;

namespace Dancord.Classes.Members
{
    public class ServerMember
    {
        public delegate void OnLeave(ServerMember member);
        public delegate void OnNicknameRemove(ServerMember member);
        public event OnLeave OnLeaving;
        public event OnNicknameRemove OnNicknameRemoving;

        private User User { get; set; }
        public Name Nickname { get => nickname; set => throw new NotImplementedException(); }
        private Name nickname;
        public DateTime JoinedAt { get; private set; }
        public RoleManager Roles { get; }
        public bool IsOwner;

        public ServerMember(User user)
        {
            this.User = user;
            this.JoinedAt = DateTime.Now;
            this.OnNicknameRemoving += delegate { this.nickname = null; };
        }
        public ServerMember(User user, bool isOwner) : this(user) => this.IsOwner = isOwner;

        public void Leave() => OnLeaving(this);
        public void RemoveNickname() => OnNicknameRemoving(this);

        public override string ToString() => Nickname is null ? User.Name : Nickname.ToString();
    }
}