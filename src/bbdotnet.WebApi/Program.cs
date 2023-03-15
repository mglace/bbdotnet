using bbdotnet.Application;
using bbdotnet.Domain;
using bbdotnet.Infrastructure;
using bbdotnet.Infrastructure.Persistence;
using bbdotnet.WebApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var sqlConnectionString =
    Environment.GetEnvironmentVariable("SqlConnectionString") ??
    throw new ApplicationException("Environment variable SqlConnectionString is not defined.");

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s => 
    {
        s.AddApiLayer()
            .AddApplicationLayer()
            .AddInfrastructureLayer(sqlConnectionString);
    })
    .Build();

InitializeDatabase(host);

host.Run();

static void InitializeDatabase(IHost host)
{ 
    using var serviceScope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

    var context = serviceScope.ServiceProvider.GetRequiredService<BBDotnetDbContext>();

    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();

    var tag = new Tag(Guid.NewGuid(), "Phish");

    context.Topics.AddRange(
        Topic.Create(
            "Hello World",
            1,
            new[] { TagId.Create(tag.Id) },
            DateTime.UtcNow
        ),
        Topic.Create(
            "Next Topic!",
            1,
            new[] { TagId.Create(tag.Id) },
            DateTime.UtcNow
        )
    );

    context.SaveChangesAsync();
}