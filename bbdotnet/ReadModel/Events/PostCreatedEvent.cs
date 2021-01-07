using System;

namespace bbdotnet
{
    public class PostCreatedEvent : BaseEvent
    {
        public string Content { get; set; }

        public PostCreatedEvent(Guid id, string content)
            : base(id)
        {
            Content = content;
        }
    }
}