using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bbdotnet.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistanceLayer(this IServiceCollection services, IConfiguration configuration)
        { 
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddScoped(_ => new BBDotnetDbContext(connectionString));

            return services;
        }
    }
}
