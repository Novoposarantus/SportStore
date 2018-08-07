using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ErrorController : Controller
    {
        [Route("~/DefaultError")]
        public ActionResult DefaultError()
        {
            return View();
        }
        [Route("~/UserNotFound")]
        public string UserNotFound()
        {
            return "User Not Found";
        }
        [Route("~/RoleNotFound")]
        public string RoleNotFound()
        {
            return "Role Not found";
        }
    }
}