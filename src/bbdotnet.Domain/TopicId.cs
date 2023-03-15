using bbdotnet.Domain.Primitives;

namespace bbdotnet.Domain;

public sealed class TopicId : ValueObject
{
    public Guid Value { get; private set; }

    private TopicId(Guid value)
    {
        Value = value;
    }

    public static TopicId CreateUnique()
    {
        return new TopicId(Guid.NewGuid());
    }

    public static TopicId Create(Guid value)
    {
        return new TopicId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
