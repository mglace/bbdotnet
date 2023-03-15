using bbdotnet.Domain.Primitives;
namespace bbdotnet.Domain.DomainEvents;

internal sealed record PostCreatedEvent(Guid Id, TopicId TopicId) : DomainEvent(Id);
