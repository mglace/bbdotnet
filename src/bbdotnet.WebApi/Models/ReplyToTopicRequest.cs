namespace bbdotnet.WebApi.Models
{
    public record ReplyToTopicRequest
    {
        public string Body { get; init; } = default!;
    }
}
