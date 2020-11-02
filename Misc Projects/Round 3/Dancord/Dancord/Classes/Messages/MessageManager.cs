using Dancord.Classes.Base;
using Dancord.Classes.Users;

namespace Dancord.Classes.Messages
{
    class MessageManager
    {
        public BasicList<Message> Messages = new BasicList<Message>();

        public void Create(User author, string content)
        {
            Message message = new Message(author, content);
            message.OnDeleting += OnDeleted(message);
            Messages.Add(message);
        }
        public OnDelete<Message> OnDeleted(Message msg)
        {
            Messages.Remove(msg);
            return null;
        }

    }
}
