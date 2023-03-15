using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Abstractions.Repositories;
using bbdotnet.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bbdotnet.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
    { 
        services.AddScoped<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        services.AddDbContext<BBDotnetDbContext>(builder => 
        {
            builder.UseSqlServer(connectionString);
        });

        services.AddSingleton<ITopicRepository, TopicRepository>();
        services.AddSingleton<IPostRepository, PostRepository>();
        services.AddSingleton<IUnitOfWork, UnitOfWork>();

        return services;
    }

}
