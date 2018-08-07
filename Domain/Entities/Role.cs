using Domain.Concrete;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public enum DefaultRoles { Admin = 1, Moderator, User }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public static Role CreateDefaultRole(DefaultRoles role)
        {
            if (!Enum.IsDefined(typeof(DefaultRoles), role))
            {
                throw new ArgumentException(nameof(role));
            }
            return new Role() { Id = (int)role, Name = role.ToString() };
        }
    }
}
