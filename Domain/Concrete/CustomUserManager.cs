using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Domain.Concrete
{
    public class CustomUserManager : UserManager<User>
    {
        public CustomUserManager(IUserStore<User> store)
        : base(store)
        {
        }

        // this method is called by Owin therefore best place to configure your User Manager
        public static CustomUserManager Create(
            IdentityFactoryOptions<CustomUserManager> options, IOwinContext context)
        {
            var manager = new CustomUserManager(
                new UserStore<User>(context.Get<SportsStoreContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }
}
