using Domain.Entities;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Abstract
{
     public interface IUsersRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Purchase> GetPurchases(string userId);
        void ChangeRole(string user, string newRole);
        void SetPurhase(Cart cart, string userName);
    }
}
