using LoginDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LoginDatabase.Repositories
{
    public abstract class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        private readonly IDbContext dbContext;

        public Repository(IDbContext dbContext) => this.dbContext = dbContext;

        public virtual void Insert(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            dbContext.Set<Entity>().Add(entity);
            dbContext.SaveChanges();
        }

        #region CRUD
        public virtual IEnumerable<Entity> Get(Expression<Func<Entity, bool>> predicate = null) => 
            predicate != null ? dbContext.Set<Entity>().Where(predicate) : dbContext.Set<Entity>();
        public virtual Entity Get(params object[] primaryKeyValues)
        {
            if (primaryKeyValues == null) throw new ArgumentNullException("primaryKeyValues");
            return dbContext.Set<Entity>().Find(primaryKeyValues);
        }
        public virtual void Update(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            dbContext.StateAsModified<Entity>(entity);
            dbContext.SaveChanges();
        }
        public virtual void Delete(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            dbContext.StateAsDeleted(entity);
            dbContext.SaveChanges();
        }
        #endregion
    }
}
