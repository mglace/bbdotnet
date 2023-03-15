using bbdotnet.Application.Abstractions.Repositories;
using bbdotnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bbdotnet.Persistence.Repositories;

internal class TopicRepository : GenericRepositoryBase<Topic, TopicId>, ITopicRepository
{
    public TopicRepository(IServiceProvider serviceProvider) : base(serviceProvider) { }

    /// <inheritdoc />
    public async Task<Topic?> GetTopicWithFlagsAsync(TopicId id, CancellationToken cancellationToken = default)
    {
        using var dbContext = DbContext;

        return await dbContext.Topics
            .Include(t => t.Flags)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
