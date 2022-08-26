using bbdotnet.Application.Common;
using bbdotnet.Application.Topics.Models;
using bbdotnet.Persistence;
using bbdotnet.Persistence.Models;
using ErrorOr;
using MapsterMapper;

namespace bbdotnet.Application.Topics.Commands
{
    public record CreateTopicCommand(string Title, string Body, int CategoryId) : ICommand<TopicDetailDTO>;

    public class CreateTopicCommandHandler : ICommandHandler<CreateTopicCommand, TopicDetailDTO>
    {
        private readonly BBDotnetDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateTopicCommandHandler(BBDotnetDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ErrorOr<TopicDetailDTO>> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = new TopicEntity(
                request.Title, 
                request.Body,
                request.CategoryId,
                DateTime.UtcNow);

            await _dbContext.Topics.AddAsync(topic, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TopicDetailDTO>(topic);
        }
    }
}
