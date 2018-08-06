using System;
using System.Web.Mvc;

namespace Domain.Exeptions
{
    class RoleNotFoundExeption : Exception
    {
        public RoleNotFoundExeption(string message) : base(message) { }
    }
    public class RoleNotFoundAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is RoleNotFoundExeption)
            {
                exceptionContext.Result = new RedirectResult("/Content/ExceptionFound.html");
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}
