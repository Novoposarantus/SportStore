using Domain.Entities;
using System.Web.Mvc;

namespace WebUI.CustomAttributes
{
    public class AutorizeRolesAttribute : AuthorizeAttribute
    {
        public AutorizeRolesAttribute(params DefaultRoles[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}