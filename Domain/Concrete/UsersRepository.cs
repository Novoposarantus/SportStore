using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Concrete
{
    public class UsersRepository : IUsersRepository
    {
        UserContext dbEntry = new UserContext();
        public IEnumerable<User> Users { get { return dbEntry.Users; } }

        public User ChangeRole(int userId, int newRoleId)
        {
            if (userId < 1 || (newRoleId < 1 && newRoleId > 3))
            {
                throw new ArgumentException();
            }
            User newUser = dbEntry.Users.Find(userId);
            newUser.RoleId = newRoleId;
            dbEntry.SaveChanges();
            return newUser;
        }
    }
}
