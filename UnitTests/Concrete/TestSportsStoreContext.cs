﻿using Domain.Entities;
using System.Data.Entity;

namespace UnitTests.Concrete
{
    public class TestSportsStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
    }

}
