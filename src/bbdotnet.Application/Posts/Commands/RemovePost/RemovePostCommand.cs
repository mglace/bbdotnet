using bbdotnet.Application.Abstractions;

namespace bbdotnet.Application.Posts.Commands;

public record RemovePostCommand(int TopicId, int Id) : ICommand;
