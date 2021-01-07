using System;
using System.Collections.Generic;
using CQRSlite.Domain;

namespace bbdotnet
{
    public class Topic : AggregateRoot
    {
        private readonly string _title;

        private readonly List<Guid> _postIds = new List<Guid>();

        public Topic(Guid id, int topicId, string title)
        {
            Id = id;
            _title = title;

            ApplyChange(new TopicCreatedEvent(id, topicId, title));
        }

        public void Reply(Guid id, string content, DateTime timestamp)
        {
            var post = new Post(id, this, content);

            _postIds.Add(id);

            ApplyChange(new TopicRepliedToEvent(Id, _postIds.Count, timestamp));
        }
    }

    public class Post : AggregateRoot
    {
        public Guid TopicId { get; }

        public Post(Guid id, Topic topic, string content)
        {
            TopicId = topic.Id;

            ApplyChange(new PostCreatedEvent(id, content));
        }
    }
}