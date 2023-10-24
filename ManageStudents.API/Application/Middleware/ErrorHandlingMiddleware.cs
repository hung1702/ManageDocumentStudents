using Newtonsoft.Json;
using ManageStudents.API.Application.Exceptions;
using System.Net;

namespace ManageStudents.API.Application.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;


        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (BaseHttpException ex)
            {
                await HandleExceptionAsync(context, ex, ex.HttpStatusCode);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                await HandleExceptionAsync(context, e, HttpStatusCode.InternalServerError);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code = HttpStatusCode.InternalServerError)
        {
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
