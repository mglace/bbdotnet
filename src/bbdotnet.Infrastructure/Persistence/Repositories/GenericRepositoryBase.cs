using bbdotnet.Application.Abstractions.Repositories;
using bbdotnet.Domain.Primitives;
using bbdotnet.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bbdotnet.Infrastructure.Persistence.Repositories;

internal abstract class GenericRepositoryBase<TEntity, TKey> : IGenericRepository<TEntity, TKey>
    where TEntity : AggregateRoot<TKey>
    where TKey : ValueObject
{
    private readonly IServiceScope _scope;

    protected BBDotnetDbContext DbContext => _scope.ServiceProvider.GetRequiredService<BBDotnetDbContext>();

    protected GenericRepositoryBase(IServiceProvider serviceProvider)
    {
        _scope = serviceProvider.CreateScope();
    }

    /// <inheritdoc />
    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        using var dbContext = DbContext;

        return await dbContext.Set<TEntity>()
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        using var dbContext = DbContext;

        await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    /// <inheritdoc />
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        using var dbContext = DbContext;

        dbContext.Set<TEntity>().Update(entity);

        return Task.CompletedTask;
    }
}
