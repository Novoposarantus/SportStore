using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        int PageSize = 4;
        IProductRepository repository;
        public ProductController(IProductRepository respository)
        {
            this.repository = respository;
        }
        [Route("ProductList")]
        [Route("")]
        public ViewResult List(string category = null,int page = 1, string nameFilter = null, bool findInDescription = false)
        {
            var products = repository.Products
                .Where(p => category == null || p.Category == category)
                .Where(p=> p.Name.ToUpper().Contains((nameFilter ?? "").ToUpper()) || 
                (findInDescription && p.Description.ToUpper().Contains((nameFilter ?? "").ToUpper()))
                );
            TempData["nameFilter"] = nameFilter;
            TempData["findInDescription"] = findInDescription;
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = products
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
        public FileContentResult GetImage(int productID)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productID);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}