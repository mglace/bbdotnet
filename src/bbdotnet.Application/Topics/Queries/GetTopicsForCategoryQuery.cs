using bbdotnet.Application.Common;
using bbdotnet.Application.Topics.Models;
using bbdotnet.Persistence;
using ErrorOr;
using Mapster;

namespace bbdotnet.Application.Topics.Queries
{
    public record GetTopicsForCategoryQuery(int CategoryId) : PagedQuery<TopicListItemDTO>;

    public class GetTopicsForCategoryQueryHandler : IPagedQueryHandler<GetTopicsForCategoryQuery, TopicListItemDTO>
    {
        private readonly BBDotnetDbContext _dbContext;

        public GetTopicsForCategoryQueryHandler(BBDotnetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ErrorOr<PagedList<TopicListItemDTO>>> Handle(GetTopicsForCategoryQuery request, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Topics
                .Where(t => t.CategoryId == request.CategoryId)
                .ProjectToType<TopicListItemDTO>()
                .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken: cancellationToken);

            return data;
        }
    }
}
