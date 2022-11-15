using ProEventos.Data.Repository;
using ProEventos.Domain.Interface;

namespace ProEventos.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependences(this IServiceCollection services)
        {
            services.AddCors();
            services.AddScoped<IEventoRepository, EventoRepository>();
            return services;
        }
    }
}
