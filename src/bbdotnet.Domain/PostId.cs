using bbdotnet.Domain.Primitives;

namespace bbdotnet.Domain;

public sealed class PostId : ValueObject
{
    public Guid Value { get; private set; }

    private PostId(Guid value)
    {
        Value = value;
    }

    public static PostId CreateUnique()
    {
        return new PostId(Guid.NewGuid());
    }

    public static PostId Create(Guid value)
    {
        return new PostId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
