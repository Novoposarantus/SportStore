using System.Web.Mvc;
using Domain.Entities;

namespace WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext , ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.Session != null)
            {
                return controllerContext.HttpContext.Session[sessionKey] = controllerContext.HttpContext.Session[sessionKey] ?? new Cart();
            }
            return new Cart();
        }
    }
}