using Domain.Entities;
using System.Linq;
using Domain.Exceptions;
using System.Data.Entity;
using System.Security.Principal;

namespace WebUI.UserHelpers
{
    public static class UserHelpers
    {
        public static bool HadPermission(this IPrincipal user, string permissionName)
        {
            User defaultUser = null;
            using (var db = new SportsStoreContext())
            {
                defaultUser = db.Users.Include(u=>u.Roles).FirstOrDefault(u => u.Email == user.Identity.Name);
            }
            if (defaultUser == null)
            {
                throw new UserNotFoundException();
            }
            foreach (UserRole role in defaultUser.Roles)
            {
                foreach(var permission in role.Permissions)
                {
                    if (permission.Name == permissionName)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
    }
}