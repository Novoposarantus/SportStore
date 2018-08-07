using System.Linq;
using WebUI.Models;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entities;
using System.Web.Security;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login")]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (var dbEntry = new SportsStoreContext())
                {
                    user = dbEntry.Users.FirstOrDefault(u => u.Email == model.Login && u.Password == model.Password);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Login, true);
                    return RedirectToAction("List", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Error. Possible incorrect login or password.");
                }
            }
            return View(model);
        }
        [Route("Registration")]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Registration")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (var dbEntry = new SportsStoreContext())
                {
                    user = dbEntry.Users.FirstOrDefault(u => u.Email == model.Login);
                }
                if (user == null)
                {
                    using (var dbEntry = new SportsStoreContext())
                    {
                        dbEntry.Users.Add(new User { Email = model.Login, Password = model.Password, Age = model.Age, Role = new Role() {Name = Domain.Entities.DefaultRoles.User.ToString() } });
                        dbEntry.SaveChanges();

                        user = dbEntry.Users.Where(u => u.Email == model.Login && u.Password == model.Password).FirstOrDefault();
                    }
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("List", "Product");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Error. A user with this name already exists.");
                }
            }

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("List", "Product");
        }
        public PartialViewResult Authentication()
        {
            return PartialView();
        }
    }
}