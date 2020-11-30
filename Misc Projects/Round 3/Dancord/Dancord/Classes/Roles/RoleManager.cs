using Dancord.Classes.Base;
using DanhoLibrary;
using System.Collections.Generic;
using System.Linq;

namespace Dancord.Classes.Roles
{
    public class RoleManager : IJSON
    {
        public class PermissionsManager : IJSON
        {
            public static PermissionsManager operator +(PermissionsManager a, PermissionsManager b)
            {
                b.Permissions.ToList().ForEach(perm => a.Permissions.Add(perm));
                return a;
            }
            public static PermissionsManager operator -(PermissionsManager a, PermissionsManager b)
            {
                b.Permissions.ToList().ForEach(perm =>
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
                public override Permission[] Array => new Permission[]
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
                    READ_MESSAGES = new Permission("READ_MESSAGES"),
                    SEND_MESSAGES = new Permission("SEND_MESSAGES"),
                    MANAGE_MESSAGES = new Permission("MANAGE_MESSAGES"),
                    REACTIONS = new Permission("REACTIONS");
                public override Permission[] Array => new Permission[]
                {
                    READ_MESSAGES,
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

            public BasicList<PermissionGroup> Permissions = new BasicList<PermissionGroup>();

            public PermissionsManager(BasicList<PermissionGroup> permissions) => this.Permissions = permissions;

            private BasicList<bool> WithAllPermissions()
            {
                var AllPermissions = new BasicList<Permission>();
                var general = new General(new Permission[] {
                            General.ADMINISTRATOR,
                            General.AUDIT_LOG,
                            General.BAN_MEMBERS,
                            General.CHANGE_NICKNAME,
                            General.KICK_MEMBERS,
                            General.MANAGE_CHANNELS,
                            General.MANAGE_NICKNAMES,
                            General.MANAGE_ROLES,
                            General.MANAGE_SERVER
                    });
                var text = new Text(new Permission[] {
                            Text.MANAGE_MESSAGES,
                            Text.REACTIONS,
                            Text.READ_MESSAGES,
                            Text.SEND_MESSAGES
                    });
                var voice = new Voice(new Permission[] {
                            Voice.CONNECT,
                            Voice.MOVE_MEMBERS,
                            Voice.MUTE_MEMBERS,
                            Voice.SPEAK
                    });
                AllPermissions.AddRange(general.Array, text.Array, voice.Array);

                var booleans = new BasicList<bool>();
                foreach (Permission perm in AllPermissions)
                    if (Permissions.Contains(perm, out bool value)) booleans.Add(value);
                    else booleans.Add(bool.Parse(perm.ToString()));

                var result = new BasicList<bool>();
                result.AddRange(booleans.ToArray());
                return result;
            }
            public string ToJSON() => WithAllPermissions().ToJSON();
        }

        private readonly BasicList<Role> Roles = new BasicList<Role>();

        public RoleManager(bool MakeDefault)
        {
            if (!MakeDefault) return;

            Roles.Add(new Role(Roles.Count, new Name("Default"), new BasicList<PermissionsManager.PermissionGroup>()
            {
                new PermissionsManager.General(PermissionsManager.General.CHANGE_NICKNAME),
                new PermissionsManager.Text(PermissionsManager.Text.READ_MESSAGES, PermissionsManager.Text.SEND_MESSAGES),
                new PermissionsManager.Voice(PermissionsManager.Voice.CONNECT, PermissionsManager.Voice.SPEAK)
            }));
        }

        public void Add(Role role) => Roles.Add(role);
        public void Remove(Role role) => Roles.Remove(role);

        public string ToJSON() =>
            "{" + 
                $"Roles: {Roles.ToJSON()}" + 
            "}";
    }
}
