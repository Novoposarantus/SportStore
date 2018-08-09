using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        int PageSize = 4;
        IUsersRepository repository;
        public UserController(IUsersRepository respository) {
            this.repository = respository;
        }
        public ViewResult ListPurchases(int page = 1, int userId) {
            var purchases = repository.GetPurchases(userId);
        }
    }
}