using Dancord.Classes.Base;
using Dancord.Classes.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dancord.Classes.Members
{
    class ServerMemberManager
    {
        private readonly BasicList<ServerMember> Members = new BasicList<ServerMember>();

        public void OnJoined(ServerMember member) => Members.Add(member);
        public void OnLeft(ServerMember member)
        {
            if (member.IsOwner)
            {
                throw new NotImplementedException();
            }

            Members.Remove(member);
        }
    }
}
