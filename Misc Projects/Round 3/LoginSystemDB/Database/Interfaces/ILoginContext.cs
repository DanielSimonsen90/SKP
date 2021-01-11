using Common.Entities;
using System.Data.Entity;

namespace LoginDatabase.Interfaces
{
    interface ILoginContext : IDbContext
    {
        DbSet<Login> Login { get; set; }

    }
}
