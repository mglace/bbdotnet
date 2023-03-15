using Ardalis.SmartEnum;

namespace bbdotnet.Application.Abstractions.Interfaces;

public class TopicSortOrder : SmartEnum<TopicSortOrder>
{
    public TopicSortOrder(string name, int value) : base(name, value) { }

    public static readonly TopicSortOrder DateOfLastPost = new(nameof(DateOfLastPost), 1);
    public static readonly TopicSortOrder Votes = new(nameof(Votes), 2);
}
