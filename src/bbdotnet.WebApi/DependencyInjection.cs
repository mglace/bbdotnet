using bbdotnet.Application.Abstractions.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace bbdotnet.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services) 
    {
        //
        // Mapster config

        var config = TypeAdapterConfig.GlobalSettings;

        config.Scan(
            Assembly.GetExecutingAssembly(),
            Application.AssemblyReference.Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddScoped<IApplicationContext, FunctionApplicationContext>();

        return services;
    }
}
