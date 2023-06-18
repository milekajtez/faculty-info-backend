using FacultyInfo.Domain.Exceptions;
using FacultyInfo.Domain.Exceptions.Details;
using System.Net;

namespace FacultyInfo.Api.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;
        private const string ErrorTemplate = "An unhandled exception occurred during the request.";

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                if (e is BaseException exception)
                {
                    response.StatusCode = (int)exception.StatusCode;
                    _logger.LogError(e, ErrorTemplate, e.StackTrace);
                    await response.WriteAsync(new ErrorDetails
                    {
                        Message = exception.Message
                    }.ToString());
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    _logger.LogError(e, ErrorTemplate, e.StackTrace);
                    await response.WriteAsync(new ErrorDetails
                    {
                        Message = e.Message
                    }.ToString());
                }
            }
        }
    }
}
