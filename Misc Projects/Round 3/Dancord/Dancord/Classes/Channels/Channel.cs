using Dancord.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dancord.Classes.Channels
{
    public abstract class Channel
    {
        public Name Name { get; private set; }
        public event OnDelete<Channel> OnDeleted;

        public Channel(string name)
        {
            this.Name = new Name(name);
        }
    }
}
