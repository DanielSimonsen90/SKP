using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dancord.Classes.Base
{
    class Permission
    {
        public string Name { get; }
        public bool Value { get; private set; }

        public Permission(string name) => this.Name = name;
        public Permission(string name, PermissionInfo info) : this(name)
        {
            switch (info)
            {
                case PermissionInfo.ALLOW: this.Value = true; break;
                case PermissionInfo.INHERIT: throw new NotImplementedException(); //break;
                case PermissionInfo.DENY: this.Value = false; break;
                default: break;
            }
        }

        public override string ToString() => Value.ToString();
    }

    public enum PermissionInfo { ALLOW, INHERIT, DENY }
}
