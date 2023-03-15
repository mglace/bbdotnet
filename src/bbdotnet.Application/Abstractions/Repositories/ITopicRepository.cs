using bbdotnet.Domain;

namespace bbdotnet.Application.Abstractions.Repositories;

public interface ITopicRepository : IGenericRepository<Topic, TopicId>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Topic?> GetTopicWithFlagsAsync(TopicId id, CancellationToken cancellationToken = default);
}
