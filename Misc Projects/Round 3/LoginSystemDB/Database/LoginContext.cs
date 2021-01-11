using LoginDatabase.Interfaces;
using System.Data.Entity;
using Common.Entities;

namespace LoginDatabase
{
    public class LoginContext : DbContext, ILoginContext
    {
        //public LoginContext(string connectionString) : base(connectionString) {}
        public DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().HasKey(pk => new { pk.Username });
        }

        public void StateAsModified<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Modified;
        public void StateAsDeleted<Entity>(Entity entity) where Entity : class => Entry(entity).State = EntityState.Deleted;
        public int ExecuteSqlCommand(string sql, params object[] parameters) => throw new System.NotImplementedException();
    }
}
