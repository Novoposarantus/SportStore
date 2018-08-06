using Domain.Abstract;
using Domain.Entities;
using Domain.Exeptions;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Concrete
{
    public class UsersRepository : IUsersRepository
    {
        SportsStoreContext dbEntry = new SportsStoreContext();
        public IQueryable<User> Users { get {
                return dbEntry.Users;
            } }
        [UserNotFound]
        [RoleNotFound]
        public User ChangeRole(int userId, string roleName)
        {
            User user = dbEntry.Users.Find(userId);
            Role role = dbEntry.Roles.FirstOrDefault(r => r.Name == roleName);
            if (user == null)
            {
                throw new UserNotFoundExeption("User not found");
            }
            if (role == null)
            {
                throw new RoleNotFoundExeption("Кole doesт't exist");
            }
            user.RoleId = role.Id;
            dbEntry.SaveChanges();
            return user;
        }
    }
}
