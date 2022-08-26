namespace bbdotnet.WebApi.Models
{
    public record CreateTopicRequest
    {
        public string Title { get; init; } = default!;

        public string Body { get; init; } = default!;

        public int CategoryId { get; init; }
    }
}
