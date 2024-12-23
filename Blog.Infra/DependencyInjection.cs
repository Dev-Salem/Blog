using Blog.Application.Common.Interfaces.Authentication;
using Blog.Application.Common.Interfaces.Persistence;
using Blog.Application.Common.Interfaces.Services;
using Blog.Infra.Authentication;
using Blog.Infra.Persistence;
using Blog.Infra.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(
            this IServiceCollection services,
            IConfigurationManager configuration
        )
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            return services;
        }
    }
}
