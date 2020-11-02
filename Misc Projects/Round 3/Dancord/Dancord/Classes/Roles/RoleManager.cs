using Dancord.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dancord.Classes.Roles
{
    public class RoleManager
    {
        public class PermissionsManager
        {
            public static PermissionsManager operator +(PermissionsManager permissions)
            {
                PermissionsManager me = new PermissionsManager();
                permissions.Permissions.ForEach(perm => me.Permissions.Add(perm));
                return me;
            }

            public class General
            {
                public static bool ADMINISTRATOR, AUDIT_LOG, MANAGE_SERVER, MANAGE_ROLES, MANAGE_CHANNELS, KICK_MEMBERS, BAN_MEMBERS, CHANGE_NICKNAME, MANAGE_NICKNAMES;
            }
            public class Text
            {

                public static bool SEE_CHANNELS, SEND_MESSAGES, MANAGE_MESSAGES;
            }
            public class Voice
            {
                public static bool CONNECT, SPEAK, MUTE_MEMBERS, MOVE_MEMBERS;
            }

            public List<bool> Permissions = new List<bool>();
        }

        private readonly BasicList<Role> Roles = new BasicList<Role>();

        public RoleManager(bool MakeDefault)
        {
            if (!MakeDefault) return;

            //Roles.Add(new Role("Default", ))
        }

        public void Add(Role role) => Roles.Add(role);
    }
}
