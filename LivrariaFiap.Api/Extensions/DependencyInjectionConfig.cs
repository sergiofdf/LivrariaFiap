using LivrariaFiap.Application.ClienteServices;
using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Infrastructure.Repository;

namespace LivrariaFiap.Api.Extensions
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDI(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            return services;
        }
    }
}
