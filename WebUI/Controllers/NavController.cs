using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Domain.Abstract;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        IProductRepository respository;
        
        public NavController(IProductRepository respository)
        {
            this.respository = respository;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = respository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView("FlexMenu",categories);
        }
    }
}