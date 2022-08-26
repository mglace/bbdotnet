using bbdotnet.Application.Common;
using bbdotnet.Application.Services;
using bbdotnet.Persistence;
using ErrorOr;

namespace bbdotnet.Application.Posts.Commands
{
    public record RemovePostCommand(int TopicId, int Id) : ICommand<bool>;

    public class RemovePostCommandHandler : ICommandHandler<RemovePostCommand, bool>
    {
        private readonly BBDotnetDbContext _dbContext;
        private readonly IApplicationContext _applicationContext;

        public RemovePostCommandHandler(BBDotnetDbContext dbContext, IApplicationContext applicationContext)
        {
            _dbContext = dbContext;
            _applicationContext = applicationContext;
        }

        public async Task<ErrorOr<bool>> Handle(RemovePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _dbContext.Posts.FindAsync(new object[] { request.Id }, cancellationToken);

            var currentUserId = _applicationContext.UserId;

            //
            // Ensure that the post was found

            if (post == null)
            {
                return Errors.Posts.NotFound;
            }

            //
            // Can't remove the first post of a thread

            var firstPostId = _dbContext.Posts
                .Where(p => p.TopicId == post.TopicId)
                .Select(p => p.Id)
                .OrderBy(p => p)
                .FirstOrDefault();

            if (firstPostId == request.Id)
            {
                return Errors.Posts.CannotRemoveFirstPost;
            }

            //
            // If there are no validation errors then proceed to remove the post

            post.Remove(currentUserId);

            await _dbContext.SaveChangesAsync(cancellationToken);

            // await _forumService.UpdateThreadStatistics(post.TopicId);

            return true;
        }
    }
}
