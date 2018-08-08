using Domain.Exceptions;
using System.Web.Mvc;

namespace WebUI.Infrastructure.CustomAttributes.ExceptionAttributes
{
    class UserNotFoundAttribute : FilterAttribute, IExceptionFilter
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