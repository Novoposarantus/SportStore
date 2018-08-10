using Domain.Abstract;
using Domain.Exceptions;
using System.Linq;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers {
    public class UserController : Controller
    {
        int PageSize = 4;
        IUsersRepository repository;
        public UserController(IUsersRepository repository) {
            this.repository = repository;
        }
        [Authorize]
        public ViewResult ListPurchases(int page = 1) {
            var user = repository.Users.FirstOrDefault(u => u.Email == System.Web.HttpContext.Current.User.Identity.Name) ?? throw new UserNotFoundException();
            var purchases = repository.GetPurchases(user.Id);
            PurchaseListViewModel model = new PurchaseListViewModel() {
                Purchases = purchases
                .OrderBy(p => p.DateBuy)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = purchases.Count()
                }
            };
            return View(model);
        }
    }
}