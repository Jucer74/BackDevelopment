using StudentsAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;



namespace StudentsAPI.MiddleWare
{
    public static class ExceptionMiddlewareExtensions
    {
        public static ErrorDetails ConstructErrorMessages(this ActionContext context)
        {
            var errors = context.ModelState.Values.Where(v => v.Errors.Count >= 1)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

            return new ErrorDetails
            {
                ErrorType = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.BadRequest),
                Errors = errors
            };
        }
        public static Task HandleExceptionAsync(this HttpContext context, Exception exception)
        {
            var httpStatusCode = GetStatusResponse(exception);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;

            var errors = new List<string>() { exception.Message };
            if(exception.InnerException is not null)
            {
                errors.Add(exception.InnerException.Message);
            }

            var errorDetails = new ErrorDetails()
            {
                ErrorType = ReasonPhrases.GetReasonPhrase(context.Response.StatusCode),
                Errors = errors
            };
            return context.Response.WriteAsync(errorDetails.ToString());
        }

        private static HttpStatusCode GetStatusResponse(Exception exception)
        {
            var nameOfException = exception.GetType().BaseType.Name;
            
            if (nameOfException.Equals("BusinessException"))
            {
                nameOfException = exception.GetType().Name;
            }

            return nameOfException switch
            {
                nameof(NotFoundException) => HttpStatusCode.InternalServerError,
                nameof(InternalServerErrorException) => HttpStatusCode.InternalServerError,

                _ => HttpStatusCode.InternalServerError
            };
        }
    }
}