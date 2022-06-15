using System.Diagnostics;

namespace MangaLibrary.UI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopwatch = Stopwatch.StartNew();
            await next(context);
            stopwatch.Stop();
            var requestTime = stopwatch.ElapsedMilliseconds;

            if (requestTime / 1000 > 2)
                _logger.LogWarning($"Request {context.Request.Method} at {context.Request.Path} took ({requestTime} ms) ");

        }
    }

    public static class RequestTimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimeHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimeMiddleware>();
        }
    }
}
