using System;

namespace bbdotnet
{
    public class TopicListItemDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PostCount { get; set; }

        public DateTime LastPostDate { get; set; }

        public Guid AggregateId { get; set; }

        public int Version { get; set; }
    }
}