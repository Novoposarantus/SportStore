﻿using Domain.Abstract;
using Domain.Entities;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Domain.Concrete
{
    public class UsersRepository : IUsersRepository
    {
        SportsStoreContext dbEntry = new SportsStoreContext();
        public IQueryable<User> Users { get {return dbEntry.Users; } }
        public IQueryable<Purchase> GetPurchases(string userId) {

            return dbEntry.Purchases.Where(p => p.UserId == userId).Include(p=>p.Products);
        }


        public void ChangeRole(string userName, string role)
        {
            throw new NotImplementedException();
            //User user = GetUser(userName);
            //Role newRole = GetRole(role);
            //user.Role = newRole;
            //user.RoleId = newRole.Id;
            //dbEntry.SaveChanges();
        }
        public void SetPurhase(Cart cart, string userName) {
            User user = GetUser(userName);
            var purchase = new Purchase() {
                DateBuy = DateTime.Now,
                User = user,
                Products = new List<CartLine>()
            };
            foreach (var line in cart.Lines) {
                purchase.Products.Add(new CartLine() {
                    Id = line.Id,
                    ProductId = line.ProductId,
                    Product = dbEntry.Products.FirstOrDefault(p=>p.ProductID == line.Product.ProductID) ?? throw new ProductNotFoundException(),
                    Quantity = line.Quantity
                });
            }
            dbEntry.Purchases.Add(purchase);
            dbEntry.SaveChanges();
        }

        User GetUser(string userName)
        {
            return dbEntry.Users.FirstOrDefault(u => u.Email == userName) ?? throw new UserNotFoundException();
        }
        //Role GetRole(DefaultRoles role)
        //{
        //    return dbEntry.Roles.FirstOrDefault(r => r.Id == (int)role) ?? throw new RoleNotFoundException();
        //}
        Product GetProduct(Product product) 
        {
            return dbEntry.Products.FirstOrDefault(p => p.ProductID == product.ProductID) ?? throw new ProductNotFoundException();
        }
    }
}
