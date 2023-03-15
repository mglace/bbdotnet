using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Topics.Models;

namespace bbdotnet.Application.Posts.Queries;

internal class GetFlaggedPostsQueryHandler : IPagedQueryHandler<GetFlaggedPostsQuery, FlaggedTopicDTO>
{
    public Task<Result<PagedList<FlaggedTopicDTO>>> Handle(GetFlaggedPostsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
