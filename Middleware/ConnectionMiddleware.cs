using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace JWTRefreshToken.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConnectionMiddleware
    {
        private readonly RequestDelegate _next;

        public ConnectionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConnectionMiddlewareExtensions
    {
        public static IApplicationBuilder UseConnectionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConnectionMiddleware>();
        }
    }
}
