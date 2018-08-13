using System.Web.Mvc;
using Domain.Exceptions;

namespace WebUI.Infrastructure.CustomAttributes.ExceptionAttributes {
    public class ProductNotFoundAttribute : FilterAttribute, IExceptionFilter {
        public void OnException(ExceptionContext exceptionContext) {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is ProductNotFoundException) {
                exceptionContext.Result = new ViewResult {
                    ViewName = "~/Content/Errors/ProductNotFoundView.cshtml"
                };
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}