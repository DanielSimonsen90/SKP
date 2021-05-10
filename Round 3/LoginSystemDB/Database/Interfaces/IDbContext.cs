using System.Data.Entity;

namespace LoginDatabase.Interfaces
{
    public interface IDbContext
    {
        DbSet<Entity> Set<Entity>() where Entity : class;

        void StateAsModified<Entity>(Entity entity) where Entity : class;
        void StateAsDeleted<Entity>(Entity entity) where Entity : class;

        int ExecuteSqlCommand(string sql, params object[] parameters);
        int SaveChanges();
    }
}
