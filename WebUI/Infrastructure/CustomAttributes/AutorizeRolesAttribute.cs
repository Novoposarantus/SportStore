using Domain.Entities;
using System.Web.Mvc;

namespace WebUI.Infrastructure.CustomAttributes
{
    public class AutorizeRolesAttribute : AuthorizeAttribute
    {
        public AutorizeRolesAttribute(params DefaultRoles[] roles) : base()
        {
            Roles = string.Join(",", roles);
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