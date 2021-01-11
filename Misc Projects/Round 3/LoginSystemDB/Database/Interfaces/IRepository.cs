using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LoginDatabase.Interfaces
{
    public interface IRepository<Entity> where Entity : class
    {
        IEnumerable<Entity> Get(Expression<Func<Entity, bool>> predicate = null);
        Entity Get(params object[] primaryKeyValues);

        void Insert(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
    }
}
