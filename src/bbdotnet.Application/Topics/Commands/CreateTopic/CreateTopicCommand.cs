using bbdotnet.Application.Abstractions;
using bbdotnet.Application.Topics.Models;
using bbdotnet.Domain;

namespace bbdotnet.Application.Topics.Commands;

public sealed record CreateTopicCommand(
    string Title, 
    string Body, 
    int CategoryId, 
    IEnumerable<TagId> TagIds
) : ICommand<TopicDetailDTO>;
