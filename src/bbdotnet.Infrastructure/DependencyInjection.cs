using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Abstractions.Interfaces;
using bbdotnet.Application.Abstractions.Repositories;
using bbdotnet.Infrastructure.Persistence;
using bbdotnet.Infrastructure.Persistence.Repositories;
using bbdotnet.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bbdotnet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IWordListProvider, StaticWordListProvider>();
        services.AddScoped<IProfanityService, ProfanityService>();

        services.AddPersistence(connectionString);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        services.AddDbContext<BBDotnetDbContext>(builder =>
        {
            builder.UseSqlite(connectionString);
        });

        services.AddSingleton<ITopicRepository, TopicRepository>();
        services.AddSingleton<IPostRepository, PostRepository>();
        services.AddSingleton<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
