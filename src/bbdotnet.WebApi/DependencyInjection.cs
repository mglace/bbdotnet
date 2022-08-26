using Mapster;
using MapsterMapper;
using System.Reflection;

namespace bbdotnet.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services) 
        {
            //
            // Mapster config

            var config = TypeAdapterConfig.GlobalSettings;

            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            //
            // ASP.NET Web API config

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            return services;
        }
    }
}
