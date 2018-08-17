using System.Web.Mvc;
using Domain.Entities;
using System.Web;

namespace WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext , ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.Session != null)
            {
                return controllerContext.HttpContext.Session[HttpContext.Current.User.Identity.Name] = controllerContext.HttpContext.Session[HttpContext.Current.User.Identity.Name] ?? new Cart();
            }
            return new Cart();
        }
    }
}