using Domain.Abstract;
using System.Web.Mvc;
using System.Web;
using System.Linq;
using Domain.Entities;

namespace WebUI.Controllers
{
    [Authorize]
    [RoutePrefix("AdministrationMenu")]
    public class AdminController : Controller
    {
        IProductRepository repository;
        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }
        [Route("Edit")]
        [Authorize()]
        public ViewResult Edit(int productID)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);
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
                repository.SaveProduct(product);
                //Сообщение о редактировании
                //TempData["message"] = string.Format($"{product.Name} has been saved");
                return RedirectToAction("List","Product");
            }
            else
            {
                return View(product);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
        public ActionResult Delete(int productID)
        {
            Product deletedProduct = repository.DeleteProduct(productID);
            //Сообщение об удалении
            //if (deletedProduct != null)
            //{
            //    TempData["message"] = string.Format($"{deletedProduct.Name} was deleted");
            //}
            return RedirectToAction("List", "Product");
        }
    }
}