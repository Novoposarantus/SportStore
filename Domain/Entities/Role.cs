using Domain.Concrete;
using System.Collections.Generic;

namespace Domain.Entities
{

    public static class RoleNames
    {
        public const string Admin = "admin";
        public const string Moderator = "moderator";
        public const string User = "user";
    }
    public class Role 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
