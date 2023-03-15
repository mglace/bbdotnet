using bbdotnet.Domain.Primitives;

namespace bbdotnet.Domain;

public abstract class Flag : Entity<Guid>
{
#pragma warning disable CS8618
    protected Flag() { }
#pragma warning restore CS8618

    public Flag(Guid id, int reasonId, string comments, MemberId flaggedBy) : base(id)
    {
        ReasonId = reasonId;
        Comments = comments;
        FlaggedBy = flaggedBy;
    }

    public int ReasonId { get; private set; }

    public string Comments { get; private set; } = default!;

    public DateTime? DateClosed { get; private set; }

    public MemberId FlaggedBy { get; private set; }

    //
    // Domain Logic

    public void Update(int reasonId, string comments)
    {
        ReasonId = reasonId;
        Comments = comments;
    }
}

public class TopicFlag : Flag
{
    private TopicFlag() : base() { }

    public TopicFlag(Guid id, int reasonId, string comments, MemberId flaggedBy)
        : base(id, reasonId, comments, flaggedBy)
    {
    }

    public Topic Topic { get; private set; } = default!;
}

public class PostFlag : Flag
{
    private PostFlag() : base() { }

    public PostFlag(Guid id, int reasonId, string comments, MemberId flaggedBy)
        : base(id, reasonId, comments, flaggedBy)
    {
    }

    public Post Post { get; private set; } = default!;
}
