using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Abstractions.Interfaces;

namespace bbdotnet.Application.Posts.Commands;

internal sealed class RemovePostCommandHandler : ICommandHandler<RemovePostCommand>
{
    private readonly IApplicationContext _applicationContext;

    public RemovePostCommandHandler(IApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public Task<Result> Handle(RemovePostCommand request, CancellationToken cancellationToken)
    {
        return Result.SuccessTask();

        //var post = await _dbContext.Posts.FindAsync(new object[] { request.Id }, cancellationToken);

        //var currentUserId = _applicationContext.UserId;

        ////
        //// Ensure that the post was found

        //if (post == null)
        //{
        //    return Errors.Posts.NotFound;
        //}

        ////
        //// Can't remove the first post of a thread

        //var firstPostId = _dbContext.Posts
        //    .Where(p => p.TopicId == post.TopicId)
        //    .Select(p => p.Id)
        //    .OrderBy(p => p)
        //    .FirstOrDefault();

        //if (firstPostId == request.Id)
        //{
        //    return Errors.Posts.CannotRemoveFirstPost;
        //}

        ////
        //// If there are no validation errors then proceed to remove the post

        //post.Remove(currentUserId);

        //await _dbContext.SaveChangesAsync(cancellationToken);

        //// await _forumService.UpdateThreadStatistics(post.TopicId);

        //return true;
    }
}
