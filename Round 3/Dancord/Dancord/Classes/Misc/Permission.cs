using System;

namespace Dancord.Classes.Base
{
    public class Permission
    {
        public string Name { get; }
        private bool Value { get; set; } = false;

        public Permission(string name) => this.Name = name;
        public Permission(string name, PermissionInfo info) : this(name) => Set(info);

        public override string ToString() => Value.ToString();

        public void Set(PermissionInfo info)
        {
            switch (info)
            {
                case PermissionInfo.ALLOW: this.Value = true; break;
                case PermissionInfo.INHERIT: throw new NotImplementedException(); //break;
                case PermissionInfo.DENY: this.Value = false; break;
                default: break;
            }
        }
    }

    public enum PermissionInfo { ALLOW, INHERIT, DENY }
}
