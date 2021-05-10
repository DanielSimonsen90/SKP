using LoginDatabase.Interfaces;
using System.Data.Entity;
using Common.Entities;

namespace LoginDatabase
{
    public class LoginContext : DbContext, ILoginContext
    {
        public DbSet<Login> Login { get; set; }
        public DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().HasKey(pk => new { pk.Username });
            modelBuilder.Entity<Message>().HasKey(pk => new { pk.Id });
        }

        public void StateAsModified<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Modified;
        public void StateAsDeleted<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Deleted;
        public int ExecuteSqlCommand(string sql, params object[] parameters) => throw new System.NotImplementedException();
    }
}
