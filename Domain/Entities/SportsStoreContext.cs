using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;


namespace Domain.Entities
{
    public class SportsStoreContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public SportsStoreContext()
            : base("SportsStoreContext", throwIfV1Schema: false)
        {
        }

        public static SportsStoreContext Create()
        {
            return new SportsStoreContext();
        }
    }
}
