using Domain.Entities;
using System.Linq;

namespace Domain.Abstract
{
     public interface IUsersRepository
    {
        IQueryable<User> Users { get; }
        void ChangeRole(string user, DefaultRoles newRole);
    }
}
