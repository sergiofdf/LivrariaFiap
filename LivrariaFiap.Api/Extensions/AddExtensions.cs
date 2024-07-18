using Carter;

namespace LivrariaFiap.Api.Extensions
{
    public static class AddExtensions
    {

        public static IServiceCollection AddExtensionServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCarter();
            return services;
        }
    }
}
