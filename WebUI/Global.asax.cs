using Domain.Concrete;
using Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using WebUI.Infrastructure.Binders;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new UserDbInitializer());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
    
    public class UserDbInitializer : DropCreateDatabaseAlways<SportsStoreContext>
    {
        protected override void Seed(SportsStoreContext db)
        {
            Role admin = new Role { Name = "Admin" };
            Role user = new Role { Name = "User" };
            Role moderator = new Role { Name = "Moderator" };
            User adminUser = new User {
                Email = "admin",
                Password = "admin",
                Age = 21,
                PhoneNumber = "+79531801740",
                Role = admin
            };
            db.Roles.Add(admin);
            db.Roles.Add(moderator);
            db.Roles.Add(user);
            db.Users.Add(adminUser);
            db.Products.Add(new Product() {
                Name = "Product1",
                Description = "DescriptionProduct1",
                Price = 123M,
                Category = "Category1"
            });
            base.Seed(db);
        }
    }
}
