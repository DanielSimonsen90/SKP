using Common.Entities;
using LoginDatabase.Exceptions;
using LoginDatabase.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LoginDatabase.Interfaces
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly ILoginContext _loginContext = new LoginContext();
        public MessageRepository(IDbContext dbContext) : base(dbContext) { }

        #region CRUD
        public Message AddMessage(Message message)
        {
            if (this.Find(message.Id) != null) throw new InvalidMessageException(InvalidMessageException.ExceptionTypes.InvalidID, "This ID is already in use!");

            var now = DateTime.Now;
            message.Timestamp = $"{now.Hour}.{now.Minute}.{now.Second}, {now.Day}/{now.Month}/{now.Year}";
            _loginContext.Message.Attach(message);
            _loginContext.Message.Add(message);
            _loginContext.SaveChanges();
            return message;
        }
        public Message GetMessage(int id) => this.Get(message => message.Id == id).FirstOrDefault();
        #endregion

        public Message Find(int id) =>
            _loginContext.Message
            .Where(message => message.Id == id)
            .AsNoTracking()
            .FirstOrDefault();

        public IEnumerable<Message> GetAllMessages() => _loginContext.Message.ToList();
    }
}
