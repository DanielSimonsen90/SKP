using Dancord.Classes.Base;
using System.Collections.Generic;

namespace Dancord.Classes.Roles
{
    public class Role
    {
        public Name Name { get; }
        private RoleManager.PermissionsManager PermissionsManager { get; set; }
        public List<RoleManager.PermissionsManager.PermissionGroup> Permissions => PermissionsManager.Permissions;

        public Role(Name name, List<RoleManager.PermissionsManager.PermissionGroup> permissions)
        {
            this.Name = name;
            this.PermissionsManager = new RoleManager.PermissionsManager(permissions);
        }
    }
}
