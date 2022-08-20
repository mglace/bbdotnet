namespace bbdotnet.Application.Topics.Models
{
    public record TopicListItemDTO
    {
        public int Id { get; init; }

        public string Title { get; init; } = default!;

        public int ReplyCount { get; init; }
    }
}
