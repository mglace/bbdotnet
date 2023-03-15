using bbdotnet.Domain.Primitives;

namespace bbdotnet.Application.Abstractions.Repositories;

public interface IGenericRepository<TEntity, TKey>
    where TEntity : AggregateRoot<TKey>
    where TKey : ValueObject
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(TEntity topic, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateAsync(TEntity topic, CancellationToken cancellationToken = default);
}
