using bbdotnet.Domain.Primitives;

namespace bbdotnet.Domain;

public sealed class TagId : ValueObject
{
    public Guid Value { get; private set; }

    private TagId(Guid value)
    {
        Value = value;
    }

    public static TagId CreateUnique()
    {
        return new TagId(Guid.NewGuid());
    }

    public static TagId Create(Guid value)
    {
        return new TagId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
