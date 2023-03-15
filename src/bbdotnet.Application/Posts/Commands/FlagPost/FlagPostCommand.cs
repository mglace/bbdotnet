using bbdotnet.Application.Abstractions;

namespace bbdotnet.Application.Posts.Commands;

public record FlagPostCommand(int Id, int ReasonId, string Comments) : ICommand;
