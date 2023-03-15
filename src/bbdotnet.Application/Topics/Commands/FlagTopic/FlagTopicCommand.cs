using bbdotnet.Application.Abstractions;
using bbdotnet.Domain;

namespace bbdotnet.Application.Topics.Commands;

public sealed record FlagTopicCommand(TopicId TopicId, int ReasonId, string Comments) : ICommand;
