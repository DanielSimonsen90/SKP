using Dancord.Classes.Base;
using Dancord.Classes.Users;
using System;

namespace Dancord.Classes.Messages
{
    public class Message
    {
        #region Events
        public event OnEdit<Message> OnEdited;
        public event OnDelete<Message> OnDeleting;
        #endregion

        #region Properties
        public User Author { get; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; }
        #endregion

        public Message(User author, string content)
        {
            this.Author = author;
            this.Content = content;
            this.CreatedAt = DateTime.Now;
        }

        #region Event Invokers
        public void Edit(string content)
        {
            if (this.Content == content) return;
            OnEdited(content, this);
            this.Content = content;
        }
        public void Delete() => OnDeleting.Invoke(this);
        #endregion
    }
}
