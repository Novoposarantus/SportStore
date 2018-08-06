using System.Web.Mvc;

namespace WebUI.CustomAttributes
{
    public class AutorizeRolesAttribute : AuthorizeAttribute
    {
        public AutorizeRolesAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}