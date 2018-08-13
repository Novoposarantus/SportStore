using Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace Domain.Concrete
{
    public class SportsStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
