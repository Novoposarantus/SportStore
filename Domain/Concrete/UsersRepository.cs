using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Concrete
{
    public class UsersRepository : IUsersRepository
    {
        SportsStoreContext dbEntry = new SportsStoreContext();
        public IEnumerable<User> Users { get {
                var role = dbEntry.Roles.ToList();
                return dbEntry.Users.ToList();
            } }

        public User ChangeRole(int userId, string roleName)
        {
            User user = dbEntry.Users.Find(userId);
            Role role = dbEntry.Roles.Find(roleName);
            if (user == null || role == null)
            {
                throw new ArgumentException();
            }
            user.RoleId = role.Id;
            dbEntry.SaveChanges();
            return user;
        }
    }
}
