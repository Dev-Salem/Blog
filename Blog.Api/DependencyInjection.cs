using Blog.Api.Common.Mapping;
using Blog.Api.Errors;
using Blog.Api.Middlewares;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Blog.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMapping();
            services.AddEndpointsApiExplorer();
            services.AddControllers();
            services.AddTransient<GlobalErrorHandlingMiddleware>();
            // services.AddControllers(options =>
            // {
            //     options.Filters.Add<ErrorHandlingFilterAttribute>();
            // });
            services.AddSingleton<ProblemDetailsFactory, BlogProblemDetailsFactory>();
            services.AddSwaggerGen();
            return services;
        }
    }
}
