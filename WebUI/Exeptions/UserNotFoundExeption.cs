using System;
using System.Web.Mvc;

namespace Domain.Exeptions
{
    class UserNotFoundExeption : Exception
    {
        public UserNotFoundExeption(string message) : base(message) { }
    }
    class UserNotFound : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is UserNotFoundExeption)
            {
                exceptionContext.Result = new RedirectResult("Views/Exeptions/UserNotFoundView");
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}
