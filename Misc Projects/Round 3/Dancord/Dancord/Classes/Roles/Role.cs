using Dancord.Classes.Base;
using System;
using System.Collections.Generic;

namespace Dancord.Classes.Roles
{
    public class Role : IJSONID
    {
        public Name Name { get; }
        public int ID { get; }
        private RoleManager.PermissionsManager PermissionsManager { get; set; }
        public List<RoleManager.PermissionsManager.PermissionGroup> Permissions => PermissionsManager.Permissions;

        public Role(int id, Name name, List<RoleManager.PermissionsManager.PermissionGroup> permissions)
        {
            this.ID = id;
            this.Name = name;
            this.PermissionsManager = new RoleManager.PermissionsManager(permissions);
        }

        public string ToJSON(bool onlyID) =>
            onlyID ?
            "{" + $"ID: {ID}" + "}" :
            "{" +
                $"Name: {Name.ToJSON()}" +
                $"ID: {ID}" +
                $"Permissions: {new NotImplementedException()}" +
            "}";

    }
}
