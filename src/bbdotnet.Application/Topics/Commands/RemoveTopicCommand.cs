using bbdotnet.Application.Common;
using bbdotnet.Application.Services;
using bbdotnet.Persistence;
using ErrorOr;

namespace bbdotnet.Application.Topics.Commands
{
    public record RemoveTopicCommand(int Id) : ICommand<bool>;

    public class RemoveTopicCommandHandler : ICommandHandler<RemoveTopicCommand, bool>
    {
        private readonly BBDotnetDbContext _dbContext;
        private readonly IApplicationContext _applicationContext;

        public RemoveTopicCommandHandler(BBDotnetDbContext dbContext, IApplicationContext applicationContext)
        {
            _dbContext = dbContext;
            _applicationContext = applicationContext;
        }

        public async Task<ErrorOr<bool>> Handle(RemoveTopicCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _applicationContext.UserId;

            var topic = await _dbContext.Topics.FindAsync(new object[] { request.Id }, cancellationToken);

            if (topic == null)
            {
                return Errors.Topics.NotFound;
            }

            topic.Remove(currentUserId);

            await _dbContext.SaveChangesAsync(cancellationToken);

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

            return true;
        }
    }
}
