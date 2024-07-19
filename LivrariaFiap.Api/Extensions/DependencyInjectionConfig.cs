using LivrariaFiap.Application.ClienteServices;
using LivrariaFiap.Application.EstoqueServices;
using LivrariaFiap.Application.LivroServices;
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
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            return services;
        }
    }
}
