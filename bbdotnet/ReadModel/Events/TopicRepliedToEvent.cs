using System;

namespace bbdotnet
{
    public class TopicRepliedToEvent : BaseEvent
    {
        public int PostCount { get; }

        public DateTime Timestamp { get; }

        public TopicRepliedToEvent(Guid id, int postCount, DateTime timestamp) 
            : base(id)
        {
            PostCount = postCount;
            Timestamp = timestamp;
        }
    }
}