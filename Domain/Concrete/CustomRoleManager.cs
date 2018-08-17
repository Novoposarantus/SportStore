using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Domain.Concrete
{
    public class CustomRoleManager : RoleManager<Role>
    {
        public CustomRoleManager(IRoleStore<Role> store) : base(store) { }

        public CustomRoleManager(IRoleStore<Role, string> store) : base(store)
        {

        }

        public static CustomRoleManager Create(
            IdentityFactoryOptions<CustomRoleManager> options, IOwinContext context)
        {
            var manager = new CustomRoleManager(
                new RoleStore<Role>(context.Get<SportsStoreContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }
}
