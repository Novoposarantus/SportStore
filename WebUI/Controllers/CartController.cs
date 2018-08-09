using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;
using System.Linq;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Exceptions;
using WebUI.Infrastructure.CustomAttributes.ExceptionAttributes;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        IProductRepository repository;
        IOrderProcessor orderProcessor;
        IUsersRepository usersRespository;
        public CartController(IProductRepository repository, IOrderProcessor orderProcessor, IUsersRepository usersRespository)
        {
            this.repository = repository;
            this.orderProcessor = orderProcessor;
            this.usersRespository = usersRespository;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        [UserNotFound]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empry!");
            }

            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated) {
                    usersRespository.SetPurhase(cart, System.Web.HttpContext.Current.User.Identity.Name);
                }
                    orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}