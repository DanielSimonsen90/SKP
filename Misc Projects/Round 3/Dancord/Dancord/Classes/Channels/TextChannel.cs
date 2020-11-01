using Dancord.Classes.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dancord.Classes.Channels
{
    class TextChannel : Channel
    {
        public static class Permissions { public static bool MANAGE_CHANNEL, READ, SEND, MANAGE_MESSAGES, REACTIONS; }

        public MessageManager Messages { get; }

        public TextChannel(string name) : base(name) {}
    }
}
