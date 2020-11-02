using Dancord.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dancord.Classes.Roles
{
    public class Role
    {
        public Name Name { get; }
        public RoleManager.PermissionsManager Permissions { get; private set; }

        public Role(Name name, RoleManager.PermissionsManager permissions)
        {
            this.Name = name;
            SetPermissions(permissions);
        }

        private void SetPermissions(RoleManager.PermissionsManager permissions)
        {
            this.Permissions = new RoleManager.PermissionsManager();
            this.Permissions += General();

            RoleManager.PermissionsManager General()
            {

            }
        }
    }
}
