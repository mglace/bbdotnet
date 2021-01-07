using System;

namespace bbdotnet
{
    public class TopicCreatedEvent : BaseEvent
    {
        public int TopicId { get; }

        public string Title { get; }

        public TopicCreatedEvent(Guid id, int topicId, string title)
            : base(id)
        {
            TopicId = topicId;
            Title = title;
        }
    }
}