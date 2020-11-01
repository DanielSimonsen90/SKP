using Dancord.Classes.Base;
using Dancord.Classes.Channels;
using Dancord.Classes.Members;
using Dancord.Classes.Users;
using System;

namespace Dancord.Classes
{
    class Server
    {
        public delegate void OnMemberJoin(ServerMember member);

        #region General Properties
        public string Name { get; }
        public DateTime CreatedAt { get; }
        #endregion

        public ChannelManager Channels { get; }
        public ServerMemberManager ServerMembers { get; }

        public OnMemberJoin OnJoining;

        public Server(string name)
        {
            this.Name = name;
            this.CreatedAt = DateTime.Now;
            
            OnJoining += ServerMembers.OnJoined;
        }

        public void AddMember(User user)
        {
            ServerMember member = new ServerMember(user);
            member.OnLeaving += ServerMembers.OnLeft;
            OnJoining(member);
        }
    }
}
