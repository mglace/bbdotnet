using System;
using CQRSlite.Events;

namespace bbdotnet
{
    public abstract class BaseEvent : IEvent
    {
        protected BaseEvent(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public int Version { get; set; } = 0;
        
        public DateTimeOffset TimeStamp { get; set; } = DateTime.UtcNow;
    }
}