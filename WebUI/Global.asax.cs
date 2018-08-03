using Domain.Concrete;
using Domain.Entities;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using WebUI.Infrastructure;
using WebUI.Infrastructure.Binders;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new UserDbInitializer());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
    public class UserDbInitializer : DropCreateDatabaseAlways<SportsStoreContext>
    {
        protected override void Seed(SportsStoreContext db)
        {
            Role admin = new Role { Name = "admin" };
            Role user = new Role { Name = "user" };
            Role moderator = new Role { Name = "moderator" };
            db.Roles.Add(admin);
            db.Roles.Add(moderator);
            db.Roles.Add(user);
            db.Users.Add(new User
            {
                Email = "admin",
                Password = "admin",
                Age = 21,
                Role = admin
            });
            base.Seed(db);
        }
    }
}
