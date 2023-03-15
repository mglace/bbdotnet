using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Abstractions.Interfaces;
using bbdotnet.Application.Abstractions.Repositories;
using bbdotnet.Application.Posts.Models;
using bbdotnet.Domain;
using MapsterMapper;

namespace bbdotnet.Application.Posts.Commands;

internal sealed class CreatePostCommandHandler : ICommandHandler<CreatePostCommand, PostDetailDTO>
{
    private readonly IMapper _mapper;
    private readonly IApplicationContext _appContext;
    private readonly IPostRepository _postRepository;
    private readonly ITopicRepository _topicRepository;

    public CreatePostCommandHandler(
        IApplicationContext appContext,
        IPostRepository postRepository,
        ITopicRepository topicRepository,
        IMapper mapper)
    {
        _appContext = appContext;
        _postRepository = postRepository;
        _topicRepository = topicRepository;
        _mapper = mapper;
    }

    public async Task<Result<PostDetailDTO>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetByIdAsync(request.TopicId, cancellationToken);

        if (topic is null)
        {
            return Result.Failure<PostDetailDTO>(Errors.Topics.NotFound);
        }

        // TODO: Get from current user
        var authorId = MemberId.Create(_appContext.UserId);

        var post = Post.Create(topic.Id, request.Body, authorId, DateTime.UtcNow);

        await _postRepository.AddAsync(post, cancellationToken);

        return _mapper.Map<PostDetailDTO>(post);
    }
}
