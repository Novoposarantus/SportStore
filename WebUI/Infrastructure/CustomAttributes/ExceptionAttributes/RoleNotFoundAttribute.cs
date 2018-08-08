using System.Web.Mvc;
using Domain.Exceptions;

namespace WebUI.Infrastructure.CustomAttributes.ExceptionAttributes
{
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
}