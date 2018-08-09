using Domain.Entities;
using System.Linq;

namespace Domain.Abstract
{
     public interface IUsersRepository
    {
        IQueryable<User> Users { get; }
        IQueryable<Purchases> GetPurchases(int userId);
        void ChangeRole(string user, DefaultRoles newRole);
        void SetPurhase(Cart cart, string userName);
    }
}
