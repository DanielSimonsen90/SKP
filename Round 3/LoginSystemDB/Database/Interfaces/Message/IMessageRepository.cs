using Common.Entities;
using System.Collections.Generic;

namespace LoginDatabase.Interfaces
{
    public interface IMessageRepository
    {
        Message AddMessage(Message message);
        IEnumerable<Message> GetAllMessages();
        Message GetMessage(int id);
    }
}
