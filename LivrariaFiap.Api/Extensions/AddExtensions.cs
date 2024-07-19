using Carter;
using LivrariaFiap.Application.Profiles;

namespace LivrariaFiap.Api.Extensions
{
    public static class AddExtensions
    {

        public static IServiceCollection AddExtensionServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddCarter();
            return services;
        }
    }
}
