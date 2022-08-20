using bbdotnet.Application.Common;
using bbdotnet.Persistence;
using ErrorOr;

namespace bbdotnet.Application.Topics.Commands
{
    public record ReplyToTopicCommand(int TopicId, string Body) : ICommand<bool>;

    public class ReplyToTopicCommandHandler : ICommandHandler<ReplyToTopicCommand, bool>
    {
        private readonly BBDotnetDbContext _dbContext;

        public ReplyToTopicCommandHandler(BBDotnetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<bool>> Handle(ReplyToTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = await _dbContext.Topics.FindAsync(new object[] { request.TopicId }, cancellationToken);

            if (topic == null)
            { 
                return Errors.Topics.NotFound;
            }

            topic.AddReply(request.Body);

            _dbContext.Update(topic);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
