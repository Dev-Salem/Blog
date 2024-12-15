using Microsoft.Extensions.DependencyInjection;

namespace Blog.infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            return services;
        }
    }
}
