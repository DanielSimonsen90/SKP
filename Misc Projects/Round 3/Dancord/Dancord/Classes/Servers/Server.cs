using Dancord.Classes.Base;
using Dancord.Classes.Channels;
using Dancord.Classes.Members;
using Dancord.Classes.Roles;
using Dancord.Classes.Users;
using DanhoLibrary;
using System;
using System.Windows;

namespace Dancord.Classes.Servers
{
    public class Server : IJSONID
    {
        #region Own Events
        public delegate void OnMemberJoin(ServerMember member);
        public delegate void OnMemberLeave(ServerMember member);
        #endregion

        #region Events
        public OnMemberJoin OnMemberJoining;
        public OnMemberLeave OnMemberLeaving;
        public OnDelete<Server> OnDelete;
        #endregion

        #region General Properties
        public Name Name { get; }
        public int ID { get; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public User Owner { get; }
        public BasicList<User> Bans = new BasicList<User>();
        #endregion

        #region Managers
        public ChannelManager Channels { get; } = new ChannelManager();
        public ServerMemberManager Members { get; } = new ServerMemberManager();
        public RoleManager Roles { get; } = new RoleManager(true);
        #endregion

        #region IJSONID
        public string ToJSON(bool onlyID) =>
            onlyID ?
            "{" + $"ID: {ID}" + "}" :
            "{" +
                $"Name: {Name.ToJSON()}" +
                $"ID: {ID}" +
                $"CreatedAt: {CreatedAt.ToLocalTime()}" +
                $"Owner: {Owner.ToJSON(true)}" +
                $"Bans: {Bans.ToJSON()}" +
                $"Channels: {Channels.ToJSON()}" +
                $"Members: {Members.ToJSON()}" +
                $"Roles: {Roles.ToJSON()}" +
            "}";
        #endregion

        public Server(string name, User owner)
        {
            this.Name = new Name(name);
            this.Owner = owner;
            this.ID = ConsoleItems.RandomNumber(0, 999999);
            while (this.ID.ToString().Length < 6) this.ID = int.Parse("0" + this.ID.ToString());

            OnMemberLeaving += OnLeft;
            OnMemberJoining += Members.OnJoined;

        }

        public void AddMember(User user)
        {
            ServerMember member = new ServerMember(user);
            member.OnLeaving += Members.OnLeft;
            OnMemberJoining(member);
        }
        public void OnLeft(ServerMember member)
        {
            if (member.IsOwner && MessageBox.Show($"Are you sure you want to DELETE \"{Name}\"?", $"Delete {Name}?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    OnDelete(this);
        }

        public override string ToString() => $"{Name} ({ID})";
    }
}
