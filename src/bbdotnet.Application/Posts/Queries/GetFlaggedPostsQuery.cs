using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Topics.Models;

namespace bbdotnet.Application.Posts.Queries;

public record GetFlaggedPostsQuery : PagedQuery<FlaggedTopicDTO>;
