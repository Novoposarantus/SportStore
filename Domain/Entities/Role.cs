using System.Collections.Generic;

namespace Domain.Entities
{
    public enum DefaultRoles { Admin = 1, Moderator, User }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
