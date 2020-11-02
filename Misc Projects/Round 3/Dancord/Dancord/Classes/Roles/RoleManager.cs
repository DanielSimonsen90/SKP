using Dancord.Classes.Base;
using DanhoLibrary;
using System.Collections.Generic;

namespace Dancord.Classes.Roles
{
    public class RoleManager
    {
        public class PermissionsManager
        {
            public static PermissionsManager operator +(PermissionsManager a, PermissionsManager b)
            {
                b.Permissions.ForEach(perm => a.Permissions.Add(perm));
                return a;
            }
            public static PermissionsManager operator -(PermissionsManager a, PermissionsManager b)
            {
                b.Permissions.ForEach(perm =>
                {
                    if (a.Permissions.Contains(perm))
                        a.Permissions.Remove(perm);
                });
                return a;
            }

            public abstract class PermissionGroup
            {
                public abstract Permission[] Array { get; }

                public PermissionGroup(params Permission[] perms)
                {
                    for (int i = 0; i < perms.Length; i++)
                    {
                        var lfPerm = Array.Find(perm => perm == perms[i]);
                        if (lfPerm != null) lfPerm.Set(PermissionInfo.ALLOW);
                    }
                }
            }

            public class General : PermissionGroup
            {
                public static Permission
                    ADMINISTRATOR = new Permission("ADMINISTRATOR"),
                    AUDIT_LOG = new Permission("AUDIT_LOG"),
                    MANAGE_SERVER = new Permission("MANAGE_SERVER"),
                    MANAGE_ROLES = new Permission("MANAGE_ROLES"),
                    MANAGE_CHANNELS = new Permission("MANAGE_CHANNELS"),
                    KICK_MEMBERS = new Permission("KICK_MEMBERS"),
                    BAN_MEMBERS = new Permission("BAN_MEMBERS"),
                    CHANGE_NICKNAME = new Permission("CHANGE_NICKNAME"),
                    MANAGE_NICKNAMES = new Permission("MANAGE_NICKNAMES");
                public override Permission[] Array => new bool[]
                {
                    ADMINISTRATOR,
                    AUDIT_LOG,
                    MANAGE_SERVER,
                    MANAGE_ROLES,
                    MANAGE_CHANNELS,
                    KICK_MEMBERS,
                    BAN_MEMBERS,
                    CHANGE_NICKNAME,
                    MANAGE_NICKNAMES
                };

                public General(params Permission[] perms) : base(perms) { }
            }
            public class Text : PermissionGroup
            {
                public static Permission
                    SEE_CHANNELS = new Permission("SEE_CHANNELS"),
                    SEND_MESSAGES = new Permission("SEND_MESSAGES"),
                    MANAGE_MESSAGES = new Permission("MANAGE_MESSAGES");
                public override Permission[] Array => new bool[]
                {
                    SEE_CHANNELS,
                    SEND_MESSAGES,
                    MANAGE_MESSAGES
                };

                public Text(params Permission[] perms) : base(perms) { }
            }
            public class Voice : PermissionGroup
            {
                public static Permission
                    CONNECT = new Permission("CONNECT"),
                    SPEAK = new Permission("SPEAK"),
                    MUTE_MEMBERS = new Permission("MUTE_MEMBERS"),
                    MOVE_MEMBERS = new Permission("MOVE_MEMBERS");
                public override Permission[] Array => new Permission[]
                {
                    CONNECT,
                    SPEAK,
                    MUTE_MEMBERS,
                    MOVE_MEMBERS
                };

                public Voice(params Permission[] perms) : base(perms) { }
            }

            public List<PermissionGroup> Permissions = new List<PermissionGroup>();

            public PermissionsManager(List<PermissionGroup> permissions) => this.Permissions = permissions;
        }

        private readonly BasicList<Role> Roles = new BasicList<Role>();

        public RoleManager(bool MakeDefault)
        {
            if (!MakeDefault) return;

            Roles.Add(new Role(new Name("Default"), new List<PermissionsManager.PermissionGroup>()
            {
                new PermissionsManager.General(PermissionsManager.General.CHANGE_NICKNAME),
                new PermissionsManager.Text(PermissionsManager.Text.SEE_CHANNELS, PermissionsManager.Text.SEND_MESSAGES),
                new PermissionsManager.Voice(PermissionsManager.Voice.CONNECT, PermissionsManager.Voice.SPEAK)
            }));
        }

        public void Add(Role role) => Roles.Add(role);
        public void Remove(Role role) => Roles.Remove(role);
    }
}
