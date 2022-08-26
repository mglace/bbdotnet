using bbdotnet.Application.Common;
using bbdotnet.Application.Topics.Models;
using bbdotnet.Persistence;
using ErrorOr;
using Mapster;

namespace bbdotnet.Application.Topics.Queries
{
    public record GetTopicsWithTagQuery(int TagId) : PagedQuery<TopicListItemDTO>;

    public class GetTopicsWithTagQueryHandler : IPagedQueryHandler<GetTopicsWithTagQuery, TopicListItemDTO>
    {
        private readonly BBDotnetDbContext _dbContext;

        public GetTopicsWithTagQueryHandler(BBDotnetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<PagedList<TopicListItemDTO>>> Handle(GetTopicsWithTagQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Topics
                .Where(t => t.Tags.Any(tg => tg.Id == request.TagId))
                .ProjectToType<TopicListItemDTO>()
                .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken: cancellationToken);

            return data;
        }
    }
}
