namespace bbdotnet.Domain.Primitives;

public abstract record DomainEvent(Guid Id) : IDomainEvent;
