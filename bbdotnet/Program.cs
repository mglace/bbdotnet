using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CQRSlite.Caching;
using CQRSlite.Commands;
using CQRSlite.Domain;
using CQRSlite.Events;
using CQRSlite.Messages;
using CQRSlite.Queries;
using CQRSlite.Routing;
using Microsoft.Extensions.DependencyInjection;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace bbdotnet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            
            services.AddMemoryCache();

            // CQRSLite

            services.AddSingleton(new Router());

            services.AddSingleton<ICommandSender>(y => y.GetService<Router>());
            services.AddSingleton<IEventPublisher>(y => y.GetService<Router>());
            services.AddSingleton<IHandlerRegistrar>(y => y.GetService<Router>());
            services.AddSingleton<IQueryProcessor>(y => y.GetService<Router>());

            services.AddSingleton<IEventStore, InMemoryEventStore>();
            
            services.AddSingleton<ICache, MemoryCache>();
            
            services.AddScoped<IRepository>(y => new CacheRepository(new Repository(y.GetService<IEventStore>()), y.GetService<IEventStore>(), y.GetService<ICache>()));
            
            services.AddScoped<ISession, Session>();

            // Scan for CommandHandlers and EventHandlers

            services.Scan(scan => scan
                .FromAssemblies(typeof(Program).GetTypeInfo().Assembly)
                .AddClasses(classes => classes.Where(x =>
                {
                    var allInterfaces = x.GetInterfaces();
                    return
                        allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IHandler<>)) ||
                        allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICancellableHandler<>)) ||
                        allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(IQueryHandler<,>)) ||
                        allInterfaces.Any(y => y.GetTypeInfo().IsGenericType && y.GetTypeInfo().GetGenericTypeDefinition() == typeof(ICancellableQueryHandler<,>));
                }))
                .AsSelf()
                .WithTransientLifetime());

            var provider = services.BuildServiceProvider();

            var registrar = new RouteRegistrar(provider);

            
            registrar.RegisterInAssemblyOf(typeof(Program));
            
            //
            // Execute

            var commandSender = provider.GetRequiredService<ICommandSender>();
            var queryProcessor = provider.GetRequiredService<IQueryProcessor>();

            //

            var aggregateId = Guid.NewGuid();

            var createTopicCommand = new CreateTopicCommand(aggregateId, "Hello World!", "This is the initial post");

            await commandSender.Send(createTopicCommand);

            // Get the read model

            var data = await queryProcessor.Query(new GetTopicByIdQuery(aggregateId));

            Console.WriteLine(JsonSerializer.Serialize(data));

            //

            var tasks = new List<Task>();
            const int limit = 499;

            for (var i = 0; i < limit; i++) {

                var replyToTopicCommand = new ReplyToTopicCommand(aggregateId, $"This is a reply #{i}", DateTime.UtcNow.AddDays(limit * -1 + i), data.Version);

                tasks.Add(commandSender.Send(replyToTopicCommand));

            }

            await Task.WhenAll(tasks);

            //

            data = await queryProcessor.Query(new GetTopicByIdQuery(aggregateId));

            Console.WriteLine(JsonSerializer.Serialize(data));

            Console.WriteLine("DONE!");
            Console.ReadKey();
        }
    }
}
