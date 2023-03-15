using bbdotnet.Application.Abstractions.Interfaces;
using bbdotnet.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace bbdotnet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddScoped<IWordListProvider, StaticWordListProvider>();
        services.AddScoped<IProfanityService, ProfanityService>();

        return services;
    }
}
