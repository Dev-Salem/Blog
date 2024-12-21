using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Middlewares
{
    public class GlobalErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = e.Message,
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "Internal Server Error",
                };
                var json = JsonSerializer.Serialize(problemDetails);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}
