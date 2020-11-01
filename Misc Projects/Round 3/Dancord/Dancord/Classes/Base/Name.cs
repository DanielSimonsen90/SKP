using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dancord.Classes.Base
{
    public class Name
    {
        public event OnChangeName ChangeName;

        private string Value;
        public Name(string value)
        {
            this.Value = value;

            ChangeName += delegate { this.Value = value; };
        }
        public override string ToString() => this.Value;
    }
}
