using Domain.Entities;
using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using Domain.Abstract;
using System.Runtime.CompilerServices;
using System.IO;

namespace WebUI.Infrastructure.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizePermissionAttribute : AuthorizeAttribute
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public AuthorizePermissionAttribute([CallerMemberName] string property = null, [CallerFilePath] string filePath = null) : base()
        {
            var callerTypeName = Path.GetFileNameWithoutExtension(filePath);
            Name = callerTypeName + property;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            User user = null;
            using (var dbEntry = new SportsStoreContext())
            {
                user = dbEntry.Users
                    .Include(u => u.Roles)
                    .FirstOrDefault(u => u.Email == httpContext.User.Identity.Name);
            }

            if (user != null)
            {
                foreach(UserRole role in user.Roles)
                {
                    foreach(var permission in role.Permissions)
                    {
                        if (permission.Name == Name)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Content/Errors/NotEnoughPermissions.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}