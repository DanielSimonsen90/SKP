using Dancord.Classes.Base;
using System;

namespace Dancord.Classes.Members
{
    public class ServerMemberManager : IJSON
    {
        public delegate void OnMemberLeave(ServerMember member);
        public OnMemberLeave OnMemberLeaving;

        private readonly BasicList<ServerMember> Members = new BasicList<ServerMember>();

        public ServerMemberManager()
        {
            OnMemberLeaving += OnLeft;
        }

        public void OnJoined(ServerMember member) => Members.Add(member);
        public void OnLeft(ServerMember member)
        {
            if (member.IsOwner)
            {
                throw new NotImplementedException();
            }

            Members.Remove(member);
        }

        public string ToJSON() =>
            "{" +
                $"Members: {Members.ToJSON()}" +
            "}";
    }
}
