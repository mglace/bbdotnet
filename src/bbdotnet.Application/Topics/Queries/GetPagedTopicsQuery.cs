using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Topics.Models;

namespace bbdotnet.Application.Topics.Queries;

public sealed record GetPagedTopicsQuery(int CategoryId) : PagedQuery<TopicListItemDTO>;
