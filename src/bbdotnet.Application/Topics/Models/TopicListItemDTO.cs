namespace bbdotnet.Application.Topics.Models;

public record TopicListItemDTO
{ 
    public string Id { get; init; } = default!;

    public string Title { get; init; } = default!;

    public int PostCount { get; init; }
}
