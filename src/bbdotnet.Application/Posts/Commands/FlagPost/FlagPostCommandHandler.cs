using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Abstractions.Interfaces;

namespace bbdotnet.Application.Posts.Commands;

internal class FlagPostCommandHandler : ICommandHandler<FlagPostCommand>
{
    private readonly IApplicationContext _applicationContext;

    public FlagPostCommandHandler(IApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public Task<Result> Handle(FlagPostCommand request, CancellationToken cancellationToken)
    {
        return Result.SuccessTask();

        //var userId = _applicationContext.UserId;

        //var post = await _dbContext.Posts.FindAsync(new object[] { request.Id }, cancellationToken);

        //if (post == null)
        //{ 
        //    return Errors.Posts.NotFound;
        //}

        //var firstPostId = await _dbContext.Posts
        //    .Include(p => p.Flags)
        //    .Where(p => p.TopicId == post.TopicId)
        //    .OrderBy(p => p.DateCreated)
        //    .Select(p => p.Id)
        //    .FirstAsync(cancellationToken);

        //// if this is the first post in a topic then flag the entire topic instead

        //if (post.Id == firstPostId)
        //{
        //    var topic = await _dbContext.Topics.FindAsync(new object[] { post.TopicId }, cancellationToken);

        //    if (topic == null)
        //    {
        //        return Errors.Topics.NotFound;
        //    }

        //    topic.Flag(request.ReasonId, request.Comments, userId);

        //    await _dbContext.SaveChangesAsync(cancellationToken);

        //    return true;
        //}

        //var flag = await _dbContext.Flags
        //    .OfType<PostFlagEntity>()
        //    .FirstOrDefaultAsync(
        //        f => f.PostId == request.Id &&
        //             f.FlaggedBy == userId &&
        //             f.DateClosed == null,
        //        cancellationToken);

        //if (flag == null)
        //{ 
        //    post.Flag(request.ReasonId, request.Comments, userId);
        //}
        //else
        //{
        //    flag.Update(request.ReasonId, request.Comments);

        //    _dbContext.Flags.Update(flag);
        //}

        //await _dbContext.SaveChangesAsync(cancellationToken);

        //return true;
    }
}
