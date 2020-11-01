using Dancord.Classes.Base;
using Dancord.Classes.Users;
using System;

namespace Dancord.Classes.Messages
{
    public class Message
    {
        public event OnEdit<Message> OnEdited;
        public event OnDelete<Message> OnDeleted;

        public User Author { get; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; }

        public Message(User author, string content)
        {
            this.Author = author;
            this.Content = content;
            this.CreatedAt = DateTime.Now;
        }

        public void Edit(string content)
        {
            if (this.Content == content) return;
            OnEdited.Invoke(content, this);
            this.Content = content;
        }
        public void Delete() => OnDeleted.Invoke(this);
    }
}
