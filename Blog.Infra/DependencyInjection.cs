using System.Text;
using Blog.Application.Common.Interfaces.Authentication;
using Blog.Application.Common.Interfaces.Persistence;
using Blog.Application.Common.Interfaces.Services;
using Blog.Infra.Authentication;
using Blog.Infra.Persistence;
using Blog.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Blog.infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(
            this IServiceCollection services,
            IConfigurationManager configuration
        )
        {
            services.AddAuth(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddPersistence();

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            return services;
        }

        private static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfigurationManager configuration
        )
        {
            JwtSettings jwtSettings = new();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton(Options.Create(jwtSettings));
            services
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Secret)
                        ),
                    }
                );
            return services;
        }
    }
}
