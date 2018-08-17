
using System.Web.Mvc;
using Domain.Exceptions;

namespace WebUI.Infrastructure.CustomAttributes
{
    public class ProductNotFoundAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is ProductNotFoundException)
            {
                exceptionContext.Result = new ViewResult
                {
                    ViewName = "~/Content/Errors/ProductNotFoundView.cshtml"
                };
                exceptionContext.ExceptionHandled = true;
            }
        }
    }

    public class RoleNotFoundAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is RoleNotFoundException)
            {
                exceptionContext.Result = new ViewResult
                {
                    ViewName = "~/Content/Errors/RoleNotFoundView.cshtml"
                };
                exceptionContext.ExceptionHandled = true;
            }
        }
    }

    public class UserNotFoundAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is UserNotFoundException)
            {
                exceptionContext.Result = new ViewResult
                {
                    ViewName = "~/Content/Errors/UserNotFoundView.cshtml"
                };
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}