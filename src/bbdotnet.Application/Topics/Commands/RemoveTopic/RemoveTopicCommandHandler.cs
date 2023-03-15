using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Abstractions.Interfaces;
using bbdotnet.Application.Abstractions.Repositories;
using bbdotnet.Domain;

namespace bbdotnet.Application.Topics.Commands;

public class RemoveTopicCommandHandler : ICommandHandler<RemoveTopicCommand>
{
    private readonly IApplicationContext _applicationContext;
    private readonly ITopicRepository _topicRepository;

    public RemoveTopicCommandHandler(IApplicationContext applicationContext, ITopicRepository topicRepository)
    {
        _applicationContext = applicationContext;
        _topicRepository = topicRepository;
    }

    public async Task<Result> Handle(RemoveTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByIdAsync(request.TopicId, cancellationToken);

        if (topic is null)
        {
            return Result.Failure(Errors.Topics.NotFound);
        }

        var currentUserId = MemberId.Create(_applicationContext.UserId);

        topic.Remove(currentUserId);

        await _topicRepository.UpdateAsync(topic, cancellationToken);

        // TODO: _forumCache.InvalidatePosts(thread.Id);

        // Clear any open flags on the thread

        //var threadFlagIds = _dbContext.ThreadFlags
        //    .Where(f => f.ThreadId == request.Id && f.DateClosed == null)
        //    .Select(f => f.Id);

        //var postFlagIds = _dbContext.PostFlags
        //    .Where(f => f.Post.ThreadId == request.Id && f.DateClosed == null)
        //    .Select(f => f.Id);

        //var flagIds = threadFlagIds.Union(postFlagIds).ToArray();

        //foreach (var flagId in flagIds)
        //{
        //    await ClearFlagAsync(flagId);
        //}

        return Result.Success();
    }
}
