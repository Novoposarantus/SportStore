using Domain.Abstract;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
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
        public void SetPurhase(Cart cart, string userName) {
            User user = GetUser(userName);
            var purchaseList = new Purchases() {
                DateBuy = DateTime.Now,
                User = user,
                Products = new List<Product>()
            };
            foreach (var product in cart.Lines) {
                for (int i = 0; i < product.Quantity;++i) {
                    purchaseList.Products.Add(product.Product);
                }
            }
            dbEntry.Purchases.Add(purchaseList);
            user.QuantityPurchases++;
            dbEntry.SaveChanges();
        }
        public IEnumerable<Purchases> GetPurchases(int userId) {
            return dbEntry.Purchases.Where(p => p.UserId == userId);
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
