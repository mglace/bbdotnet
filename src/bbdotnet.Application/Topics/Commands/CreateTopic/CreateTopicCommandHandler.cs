using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Abstractions.Interfaces;
using bbdotnet.Application.Abstractions.Repositories;
using bbdotnet.Application.Topics.Models;
using bbdotnet.Domain;
using MapsterMapper;

namespace bbdotnet.Application.Topics.Commands;

public class CreateTopicCommandHandler : ICommandHandler<CreateTopicCommand, TopicDetailDTO>
{
    private readonly ITopicRepository _topicRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IApplicationContext _appContext;
    private readonly IMapper _mapper;

    public CreateTopicCommandHandler(
        IApplicationContext appContext,
        IMapper mapper, 
        ITopicRepository topicRepository,
        IUnitOfWork unitOfWork)
    {
        _appContext = appContext;
        _mapper = mapper;
        _topicRepository = topicRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TopicDetailDTO>> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var timestamp = DateTime.UtcNow;

        var authorId = MemberId.Create(_appContext.UserId);

        var topic = Topic.Create(
            request.Title,
            request.CategoryId,
            request.Body,
            authorId,
            request.TagIds,
            timestamp);
    
        await _topicRepository.AddAsync(topic, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TopicDetailDTO>(topic);
    }
}
