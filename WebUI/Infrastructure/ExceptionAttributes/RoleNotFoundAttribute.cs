using System.Web.Mvc;
using Domain.Exceptions;

namespace WebUI.Infrastructure.ExceptionAttributes
{
    public class RoleNotFoundAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is RoleNotFoundException)
            {
                exceptionContext.Result = new RedirectResult("/Content/RoleNotFoundView.html");
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}