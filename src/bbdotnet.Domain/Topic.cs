using bbdotnet.Domain.Exceptions;
using bbdotnet.Domain.Primitives;

namespace bbdotnet.Domain;

public class Topic : AggregateRoot<TopicId>
{
    public static readonly int MaxTitleLength = 45;

#pragma warning disable CS8618
    private Topic() { }
#pragma warning restore CS8618

    internal Topic(TopicId id, string title, int categoryId, DateTime timestamp) : base(id)
    {
        Title = title;
        CategoryId = categoryId;
        DateCreated = timestamp;

        //_replies = new List<Post>();
    }

    public string Title { get; private set; }

    public int PostCount { get; private set; }
    
    public DateTime? DateOfLastPost { get; private set; }

    public int CategoryId { get; private set; }

    public DateTime DateCreated { get; private set; }

    public bool IsRemoved { get; private set; }

    public MemberId? RemovedBy { get; private set; }

    public DateTime? DateRemoved { get; private set; }

    public bool IsClosed { get; private set; }


    //
    // Navigation properties

    private readonly List<TagId>? _tagIds = null;

    public IReadOnlyCollection<TagId> TagIds =>
        _tagIds?.AsReadOnly() ?? throw new CollectionNotInitializedException(nameof(TagIds));

    private readonly List<TopicFlag>? _flags = null;

    public IReadOnlyCollection<TopicFlag> Flags =>
        _flags?.AsReadOnly() ?? throw new CollectionNotInitializedException(nameof(Flags));

    //
    // Domain Logic

    public void Remove(MemberId currentUserId)
    {
        IsRemoved = true;
        RemovedBy = currentUserId;
        DateRemoved = DateTime.UtcNow;

        Close();
    }

    public void Close()
    {
        IsClosed = true;
    }

    //public void Archive(int currentUserId)
    //{
    //    IsArchived = true;
    //}

    public TopicFlag Flag(int reasonId, string comments, MemberId currentUserId)
    {
        if (_flags is null) throw new CollectionNotInitializedException(nameof(Flags));

        TopicFlag flag = new(Guid.NewGuid(), reasonId, comments, currentUserId);

        _flags.Add(flag);

        return flag;
    }

    public static Topic Create(string title, int categoryId, IEnumerable<TagId> tagIds, DateTime timestamp)
    {
        var topic = new Topic(
            TopicId.CreateUnique(),
            title,
            categoryId,
            timestamp);

        return topic;
    }

    public void ApplyTags(params TagId[] tagIds)
    { 
        if (_tagIds is null)
        { 
            throw new CollectionNotInitializedException(nameof(TagIds));
        }

        foreach (var tagId in tagIds) 
        {
            _tagIds.Add(tagId);
        }
    }
}
