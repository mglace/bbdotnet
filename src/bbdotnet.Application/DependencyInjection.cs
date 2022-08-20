using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace bbdotnet.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        { 
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
