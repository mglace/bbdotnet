using Dapper;
using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Topics.Models;
using bbdotnet.Application.Abstractions.Repositories;

namespace bbdotnet.Application.Topics.Queries;

internal sealed class GetPagedTopicsQueryHandler : IPagedQueryHandler<GetPagedTopicsQuery, TopicListItemDTO>
{
    private readonly ITopicRepository _repo;
    private readonly ISqlConnectionFactory _connectionFactory;

    public GetPagedTopicsQueryHandler(ITopicRepository repo, ISqlConnectionFactory connectionFactory)
    {
        _repo = repo;
        _connectionFactory = connectionFactory;
    }

    public async Task<Result<PagedList<TopicListItemDTO>>> Handle(GetPagedTopicsQuery request, CancellationToken cancellationToken)
    {
        await using var sqlConnection = _connectionFactory.CreateConnection();

        var topics = await sqlConnection.QueryAsync<TopicListItemDTO>("SELECT Id, Title, PostCount FROM Topic");

        return new PagedList<TopicListItemDTO>(topics, 0, false, false);
    }
}
