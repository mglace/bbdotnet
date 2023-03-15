using bbdotnet.Application.Abstractions.Repositories;
using bbdotnet.Domain.Primitives;
using MediatR;

namespace bbdotnet.Infrastructure.Persistence.Repositories;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly BBDotnetDbContext _dbContext;
    private readonly IPublisher _publisher;

    public UnitOfWork(BBDotnetDbContext dbContext, IPublisher publisher)
    {
        _dbContext = dbContext;
        _publisher = publisher;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await RaiseDomainEvents(cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private async Task RaiseDomainEvents(CancellationToken cancellationToken = default)
    {
        var domainEvents = _dbContext.ChangeTracker
            .Entries<IAggregateRoot>()
            .Select(x => x.Entity)
            .SelectMany(aggregateRoot =>
            {
                var domainEvents = aggregateRoot.GetDomainEvents();

                aggregateRoot.ClearDomainEvents();

                return domainEvents;
            })
            .ToArray();

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }
    }
}
