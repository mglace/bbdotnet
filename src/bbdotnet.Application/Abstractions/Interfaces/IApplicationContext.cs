namespace bbdotnet.Application.Abstractions.Interfaces;

public interface IApplicationContext
{
    Guid UserId { get; }

    bool TryGetUserId(out Guid id);
}
