using bbdotnet.Domain.Primitives;

namespace bbdotnet.Domain;

public sealed class MemberId : ValueObject
{
    public Guid Value { get; private set; }

    private MemberId(Guid value)
    {
        Value = value;
    }

    public static MemberId CreateUnique()
    {
        return new MemberId(Guid.NewGuid());
    }

    public static MemberId Create(Guid value)
    {
        return new MemberId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
