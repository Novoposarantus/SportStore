using Domain.Concrete;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Abstract
{
     public interface IUsersRepository
    {
        IQueryable<User> Users { get; }
        User ChangeRole(int userId, string roleName);
    }
}
