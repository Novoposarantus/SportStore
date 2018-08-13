using Domain.Entities;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Abstract
{
     public interface IUsersRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Purchase> GetPurchases(int userId);
        void ChangeRole(string user, DefaultRoles newRole);
        void SetPurhase(Cart cart, string userName);
    }
}
