using bbdotnet.Domain.Primitives;

namespace bbdotnet.Domain;

public class Tag : Entity<Guid>
{
    private Tag() { }

    public Tag(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; } = default!;
}
