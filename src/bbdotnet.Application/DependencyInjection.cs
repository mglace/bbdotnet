using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using bbdotnet.Application.Common.Behaviors.Validation;

namespace bbdotnet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    { 
        services.AddMediatR(c => c.RegisterServicesFromAssembly(AssemblyReference.Assembly));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);

        return services;
    }
}
