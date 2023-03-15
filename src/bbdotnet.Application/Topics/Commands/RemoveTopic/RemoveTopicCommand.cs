using bbdotnet.Application.Abstractions;
using bbdotnet.Domain;

namespace bbdotnet.Application.Topics.Commands;

public record RemoveTopicCommand(TopicId TopicId) : ICommand;
