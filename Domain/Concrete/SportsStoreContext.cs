using Domain.Entities;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class SportsStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
    }

}
