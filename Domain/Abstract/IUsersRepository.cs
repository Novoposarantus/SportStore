using Domain.Concrete;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstract
{
     public interface IUsersRepository
    {
        IEnumerable<User> Users { get; }
        User ChangeRole(int userId, string roleName);
    }
}
