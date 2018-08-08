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
            User user = GetUser(userName);
            Role newRole = GetRole(role);
            user.Role = newRole;
            user.RoleId = newRole.Id;
            dbEntry.SaveChanges();
        }
        User GetUser(string userName)
        {
            return dbEntry.Users.FirstOrDefault(u => u.Email == userName) ?? throw new UserNotFoundException();
        }
        Role GetRole(DefaultRoles role)
        {
            return dbEntry.Roles.FirstOrDefault(r => r.Id == (int)role) ?? throw new RoleNotFoundException();
        }
    }
}
