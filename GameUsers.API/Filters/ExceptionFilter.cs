using GameUsers.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameUsers.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is GameUsersExceptions exceptions)
            {
                var errorResponse = new
                {
                    errors = exceptions.GetErrors()
                };

                context.Result = new ObjectResult(errorResponse)
                {
                    StatusCode = (int)exceptions.GetHttpStatusCode()
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
