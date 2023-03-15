namespace bbdotnet.WebApi.Models;

public record FlagTopicRequest(Guid TopicId, int ReasonId, string Comments);
