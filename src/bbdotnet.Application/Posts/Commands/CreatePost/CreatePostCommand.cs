using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Posts.Models;
using bbdotnet.Domain;

namespace bbdotnet.Application.Posts.Commands;

public sealed record CreatePostCommand(TopicId TopicId, string Body) : ICommand<PostDetailDTO>;
