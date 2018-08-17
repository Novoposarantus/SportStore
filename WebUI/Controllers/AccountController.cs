using WebUI.Models;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entities;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;

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
                var userManager = HttpContext.GetOwinContext().GetUserManager<CustomUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                User user = userManager.Find(model.Login, model.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);
                    return Redirect(/*model.ReturnUrl ??*/ Url.Action("List", "Product"));
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }
        [Route("Registration")]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Registration")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<CustomUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                var user = new User { UserName = model.Email, Email = model.Email, Age = model.Age, PhoneNumber = model.PhoneNumber};
                var result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    //var identityClaim = new IdentityUserClaim {ClaimType = "Permission", ClaimValue = model. }
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = false }, ident);

                    return Redirect(Url.Action("List", "Products"));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return View(model);
            }
            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }
        public ActionResult Logoff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("List", "Product");
        }
        public PartialViewResult Authentication()
        {
            return PartialView();
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}