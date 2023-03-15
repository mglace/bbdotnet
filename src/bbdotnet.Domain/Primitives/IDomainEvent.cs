using MediatR;

namespace bbdotnet.Domain.Primitives;

public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}

