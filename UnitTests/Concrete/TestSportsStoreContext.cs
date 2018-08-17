using Domain.Entities;
using System.Data.Entity;

namespace UnitTests.Concrete
{
    public class TestSportsStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }

}
