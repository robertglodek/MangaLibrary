using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using System.Net;

namespace MangaLibrary.UI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                Console.WriteLine("SIema");
                await next(context);
            }
            catch (Exception exception)
            { 
                _logger.LogError(exception,exception.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var errorModel = new ErrorModel(ErrorType.publicServerError);
                await context.Response.WriteAsJsonAsync(errorModel);
            }
        }
    }
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }


}
