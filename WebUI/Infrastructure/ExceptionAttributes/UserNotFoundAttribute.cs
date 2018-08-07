using Domain.Exceptions;
using System.Web.Mvc;

namespace WebUI.Infrastructure.ExceptionAttributes
{
    class UserNotFoundAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is UserNotFoundException)
            {
                exceptionContext.Result = new RedirectResult("~/UserNotFound",true);
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}