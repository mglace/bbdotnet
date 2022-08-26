using bbdotnet.Application.Common;
using bbdotnet.Application.Posts.Models;
using bbdotnet.Persistence;
using ErrorOr;

namespace bbdotnet.Application.Posts.Commands
{
    public record ReplyToTopicCommand(int TopicId, string Body) : ICommand<PostDetailDTO>;

    internal class ReplyToTopicCommandHandler : ICommandHandler<ReplyToTopicCommand, PostDetailDTO>
    {
        private readonly BBDotnetDbContext _dbContext;

        public ReplyToTopicCommandHandler(BBDotnetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<PostDetailDTO>> Handle(ReplyToTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = await _dbContext.Topics.FindAsync(new object[] { request.TopicId }, cancellationToken);

            if (topic == null)
            {
                return Errors.Topics.NotFound;
            }

            var timestamp = DateTime.UtcNow;

            var post = topic.AddReply(request.Body, timestamp, _dbContext);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new PostDetailDTO
            {
                Id = post.Id
            };
        }
    }
}
