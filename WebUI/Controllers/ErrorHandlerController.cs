using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ErrorHandlerController : Controller
    {
        [Route("~/DefaultError")]
        public ActionResult Default()
        {
            return View("Standart Error");
        }
        [Route("~/PageNotFound")]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}