using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    public class Role : IdentityRole
    {
        public Role() : base() { }
        public Role(string name) : base(name) { }
    }
}
