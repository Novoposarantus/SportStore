using Domain.Abstract;
using Domain.Entities;
using Domain.Exceptions;
using System.Linq;

namespace Domain.Concrete
{
    public class UsersRepository : IUsersRepository
    {
        SportsStoreContext dbEntry = new SportsStoreContext();
        public IQueryable<User> Users { get {return dbEntry.Users; } }
        public User ChangeRole(int userId, string roleName)
        {
            throw new UserNotFoundException();
            User user = dbEntry.Users.Find(userId);
            Role role = dbEntry.Roles.FirstOrDefault(r => r.Name == roleName);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            if (role == null)
            {
            }
            user.RoleId = role.Id;
            dbEntry.SaveChanges();
            return user;
        }
    }
}
