using Domain.Entities;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
