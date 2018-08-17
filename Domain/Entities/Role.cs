using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Role : IdentityRole
    {
        public ICollection<Permission> Permissions { get; set; }

        public Role() : base() { }
        public Role(string name) : base(name) { }
    }
    public class UserRole : IdentityUserRole
    {
        public ICollection<Permission> Permissions { get; set; }
    }
}
