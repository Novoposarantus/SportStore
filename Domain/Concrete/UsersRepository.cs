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
        public void ChangeRole(string userName, DefaultRoles role)
        {
            throw new UserNotFoundException();
            User user = dbEntry.Users.FirstOrDefault(u => u.Email == userName);
            Role newRole = dbEntry.Roles.FirstOrDefault(r => r.Id == (int)role);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            if (newRole == null)
            {
                throw new RoleNotFoundException();
            }

            user.Role = newRole;
            user.RoleId = newRole.Id;
            dbEntry.SaveChanges();
        }
    }
}
