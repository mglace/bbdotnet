using bbdotnet.Domain.DomainEvents;
using bbdotnet.Domain.Exceptions;
using bbdotnet.Domain.Primitives;

namespace bbdotnet.Domain;

public class Post : AggregateRoot<PostId>
{
    public static readonly int MaxBodyLength = 3000;

#pragma warning disable CS8618
    private Post() { }
#pragma warning restore CS8618

    private Post(PostId id, TopicId topicId, string body, MemberId authorId, DateTime? timestamp = null) : base(id) 
    { 
        TopicId = topicId;
        Body = body;
        AuthorId = authorId;
        DateCreated = timestamp ?? DateTime.UtcNow;

        RaiseDomainEvent(new PostCreatedEvent(Guid.NewGuid(), topicId));

        _flags = new List<PostFlag>();
    }

    public string Body { get; private set; }

    public MemberId AuthorId { get; private set; }

    public TopicId TopicId { get; private set; }

    public DateTime DateCreated { get; private set; }

    public bool IsRemoved { get; private set; }

    public MemberId? RemovedBy { get; private set; }

    public DateTime? DateRemoved { get; private set; }

    //
    // Navigation Properties


    private readonly List<PostFlag>? _flags = null;

    public IReadOnlyCollection<PostFlag> Flags => 
        _flags?.AsReadOnly() ?? throw new CollectionNotInitializedException(nameof(Flags));

    //
    // Domain Logic

    public static Post Create(TopicId topicId, string body, MemberId authorId, DateTime timestamp)
    { 
        return new Post(PostId.CreateUnique(), topicId, body, authorId, timestamp);
    }

    public void Remove(MemberId memberId)
    {
        IsRemoved = true;
        DateRemoved = DateTime.UtcNow;
        RemovedBy = memberId;
    }

    public PostFlag Flag(int reasonId, string comments, MemberId memberId)
    {
        if (_flags is null) throw new CollectionNotInitializedException(nameof(Flags));

        PostFlag flag = new(
            Guid.NewGuid(),
            reasonId, 
            comments,
            memberId);

        _flags.Add(flag);

        return flag;
    }
}
