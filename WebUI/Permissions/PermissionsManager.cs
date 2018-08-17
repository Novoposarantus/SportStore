using Domain.Entities;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using WebUI.Infrastructure.CustomAttributes;

namespace WebUI.Permissions
{
    public class PermissionsManager
    {
        public static void UpdateListPermissions()
        {
            SportsStoreContext db = new SportsStoreContext();
            
            Assembly asm = Assembly.GetExecutingAssembly();
            var permissions = (from type in asm.GetTypes()
                        where typeof(Controller).IsAssignableFrom(type)
                        from method in type.GetMethods()
                        where method.IsDefined(typeof(AuthorizePermissionAttribute))
                        select new Permission() { Name = type.ToString()+ method.Name,
                            Description = method.GetCustomAttribute<AuthorizePermissionAttribute>().Description }).ToList();
            
            foreach (var dbPermission in db.Permissions)
            {
                var newPermission = permissions.FirstOrDefault(attributePermission => 
                    dbPermission.Name.Contains(attributePermission.Name)
                    && attributePermission.Description == dbPermission.Description);

                if (newPermission == null)
                {
                    //Update the current permissions
                    dbPermission.Description = newPermission.Description;
                    permissions.Remove(newPermission);
                }
                else
                {
                    //Removes unused permission
                    db.Permissions.Remove(dbPermission);
                }
            }

            foreach (var permission in permissions)
            {
                db.Permissions.Add(permission);
            }
            db.SaveChanges();
        }
    }
}