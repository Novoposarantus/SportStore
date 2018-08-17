using Domain.Abstract;
using Domain.Entities;
using System.Web.Mvc;
using System.Web;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using Domain.Concrete;
using Microsoft.AspNet.Identity;
using WebUI.Infrastructure.CustomAttributes;

namespace WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IProductRepository productRepository;
        IUsersRepository userRepository;
        public AdminController(IProductRepository productRepository, IUsersRepository userRepository)
        {
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }
        [Route("EditProduct")]
        [AuthorizePermission(Description = "Edit products")]
        public ViewResult EditProduct(int productID)
        {
            Product product = productRepository.Products.FirstOrDefault(p => p.ProductID == productID);
            return View(product);
        }
        [HttpPost]
        [Route("EditProduct")]
        [AuthorizePermission(Description = "Edit products")]
        public ActionResult EditProduct(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                productRepository.SaveProduct(product);
                //Сообщение о редактировании
                //
                //TempData["message"] = string.Format($"{product.Name} has been saved");
                //
                return RedirectToAction("List", "Product");
            }
            else
            {
                return View(product);
            }
        }
        [Route("CreateProduct")]
        [AuthorizePermission(Description = "Create Products")]
        public ViewResult CreateProduct()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
        [AuthorizePermission(Description = "Delete Users")]
        public ActionResult Delete(int productID)
        {
            Product deletedProduct = productRepository.DeleteProduct(productID);
            //Сообщение об удалении
            //if (deletedProduct != null)
            //{
            //    TempData["message"] = string.Format($"{deletedProduct.Name} was deleted");
            //}
            return RedirectToAction("List", "Product");
        }
        [Route("~/Administration/ListUsers")]
        [AuthorizePermission(Description = "Show List registered usrers")]
        public ViewResult ListUsers()
        {
            return View(userRepository.Users.Include(p => p.Roles));
        }
        
        [HttpPost]
        [UserNotFound]
        [RoleNotFound]
        [AuthorizePermission(Description = "Change the roles of users")]
        public ActionResult ChangeRole(string user, string role)
        {
            userRepository.ChangeRole(user, role);
            return RedirectToAction("ListUsers", "Admin");
        }

        [Route("~/Administration/CreateRole")]
        [AuthorizePermission(Description = "Create roles")]
        public ViewResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [AuthorizePermission(Description = "Create roles")]
        public ActionResult CreateRole(string roleName)
        {
            var roleManager = HttpContext.GetOwinContext().GetUserManager<CustomRoleManager>();

            if (!roleManager.RoleExists(roleName))
                roleManager.Create(new Role(roleName));
            return RedirectToAction("ListUsers", "Admin");
        }
        [Route("~/Administration/EditRole")]
        [AuthorizePermission(Description = "Editing Roles")]
        public ViewResult EditRole()
        {
            return View();
        }

        [HttpPost]
        [AuthorizePermission(Description = "Editing Roles")]
        public ActionResult EditRole(string roleName)
        {
            return RedirectToAction("ListUsers", "Admin");
        }
    }
}