using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using JWTRefreshToken.Auth;
using System.Text.Json;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace JWTRefreshToken.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware:IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;


        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;

        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                //handle exception
                var traceId = Guid.NewGuid();
                _logger.LogError($"Error occure while processing the request, TraceId : ${traceId}, Message : ${ex.Message}, StackTrace: ${ex.StackTrace}");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var problemDetails = new ProblemDetails
                {
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    Title = "Internal Server Error",
                    Status = (int)StatusCodes.Status500InternalServerError,
                    Instance = context.Request.Path,
                    Detail = $"Internal server error occured, traceId : {traceId}",
                };
                await context.Response.WriteAsJsonAsync(problemDetails);

            }
        }
       
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
