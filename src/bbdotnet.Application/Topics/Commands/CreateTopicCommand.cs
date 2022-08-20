using bbdotnet.Application.Common;
using bbdotnet.Application.Topics.Models;
using bbdotnet.Persistence;
using bbdotnet.Persistence.Models;
using ErrorOr;

namespace bbdotnet.Application.Topics.Commands
{
    public record CreateTopicCommand(string Title, string Body) : ICommand<TopicDetailDTO>;

    public class CreateTopicCommandHandler : ICommandHandler<CreateTopicCommand, TopicDetailDTO>
    {
        private readonly BBDotnetDbContext _dbContext;

        public CreateTopicCommandHandler(BBDotnetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<TopicDetailDTO>> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = new TopicEntity(request.Title, request.Body);

            await _dbContext.Topics.AddAsync(topic, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new TopicDetailDTO();
        }
    }
}
