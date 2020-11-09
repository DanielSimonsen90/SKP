using Dancord.Classes.Base;
using Dancord.Classes.Messages;
using Dancord.Classes.Roles;

namespace Dancord.Classes.Channels
{
    class TextChannel : Channel
    {
        public class Permissions
        {
            public Permission
                MANAGE_CHANNEL = RoleManager.PermissionsManager.General.MANAGE_CHANNELS,
                READ = RoleManager.PermissionsManager.Text.READ_MESSAGES,
                SEND = RoleManager.PermissionsManager.Text.SEND_MESSAGES,
                REACTIONS = RoleManager.PermissionsManager.Text.REACTIONS;
        }

        public MessageManager Messages { get; }

        public TextChannel(string name, int id) : base(name, id) { }
    }
}
