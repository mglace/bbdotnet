using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Abstractions.Interfaces;
using bbdotnet.Application.Abstractions.Repositories;
using bbdotnet.Domain;

namespace bbdotnet.Application.Topics.Commands;

internal class FlagTopicCommandHandler : ICommandHandler<FlagTopicCommand>
{
    private readonly IApplicationContext _applicationContext;
    private readonly ITopicRepository _topicRepository;

    public FlagTopicCommandHandler(IApplicationContext applicationContext, ITopicRepository topicRepository)
    {
        _applicationContext = applicationContext;
        _topicRepository = topicRepository;
    }

    public async Task<Result> Handle(FlagTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetTopicWithFlagsAsync(request.TopicId, cancellationToken);

        if (topic is null)
        {
            return Result.Failure(Errors.Topics.NotFound);
        }

        var currentUserId = MemberId.Create(_applicationContext.UserId);

        topic.Flag(request.ReasonId, request.Comments, currentUserId);

        await _topicRepository.UpdateAsync(topic, cancellationToken);

        return Result.Success();
    }
}
