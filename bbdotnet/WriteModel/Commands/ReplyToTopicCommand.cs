using System;

namespace bbdotnet
{
    public class ReplyToTopicCommand : BaseCommand
    {
        public ReplyToTopicCommand(Guid aggregateId, string content, DateTime timestamp, int expectedVersion)
            : base(aggregateId, expectedVersion)
        {
            Content = content;
            Timestamp = timestamp;
        }

        public string Content { get; }
        public DateTime Timestamp { get; }
    }
}