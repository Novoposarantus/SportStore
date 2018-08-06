using Domain.Abstract;
using System.Web.Mvc;
using System.Web;
using System.Linq;
using System.Data.Entity;
using Domain.Entities;
using WebUI.CustomAttributes;

namespace WebUI.Controllers
{
    [AutorizeRoles(RoleNames.Admin,RoleNames.Moderator)]
    [RoutePrefix("Moderation")]
    public class AdminController : Controller
    {
        IProductRepository productRepository;
        IUsersRepository userRepository;
        public AdminController(IProductRepository productRepository, IUsersRepository userRepository)
        {
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }
        [Route("Edit")]
        public ViewResult Edit(int productID)
        {
            Product product = productRepository.Products.FirstOrDefault(p => p.ProductID == productID);
            return View(product);
        }
        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
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
                //TempData["message"] = string.Format($"{product.Name} has been saved");
                return RedirectToAction("List","Product");
            }
            else
            {
                return View(product);
            }
        }
        [Route("Create")]
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
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
        [AutorizeRoles(RoleNames.Admin)]
        [Route("~/Administration/ListUsers")]
        public ViewResult ListUsers()
        {
            return View(userRepository.Users.Include(p => p.Role));
        }
        [HttpPost]
        [AutorizeRoles(RoleNames.Admin)]
        public ActionResult ChangeRole(int userId, string roleName)
        {
            User user = userRepository.ChangeRole(userId, roleName); 
            //Сообщение об изменении роли
            return RedirectToAction("ListUsers", "Admin");
        }
    }
}