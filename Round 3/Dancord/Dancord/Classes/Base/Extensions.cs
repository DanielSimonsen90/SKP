using System.Linq;

namespace Dancord.Classes.Base
{
    public static class Extensions
    {
        public static bool Contains(this BasicList<Roles.RoleManager.PermissionsManager.PermissionGroup> caller, Permission perm, out bool value)
        {
            foreach (var group in caller)
                foreach (Permission p in group.Array)
                    if (p.Name == perm.Name)
                    {
                        value = bool.Parse(p.ToString());
                        return true;
                    }
            return value = false;
        }
        public static BasicList<Permission> AddRange(this BasicList<Permission> me, params Permission[][] permissions)
        {
            foreach (var arr in permissions)
                me.AddRange(arr);
            return me;
        }
    }
}
