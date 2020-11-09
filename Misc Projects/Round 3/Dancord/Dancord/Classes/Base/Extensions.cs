namespace Dancord.Classes.Base
{
    public static class Extensions
    {
        public static bool Contains(this BasicList<Roles.RoleManager.PermissionsManager.PermissionGroup> caller, Permission perm, out bool value = false)
        {

            foreach (var group in caller)
                foreach (var p in group.Array)
                    if (p.Name == perm.Name)
                    {
                        value = p.value;
                        return true;
                    }
            return false;
        }
    }
}
