namespace bbdotnet.Persistence.Models
{
    public class PostEntity : IEntity
    {
        private PostEntity() { }

        public PostEntity(string body, DateTime timestamp) 
        { 
            Body = body;
            DateCreated = timestamp;
        }

        public PostEntity(string body, DateTime timestamp, int topicId)
        {
            Body = body;
            DateCreated = timestamp;

            TopicId = topicId;
        }

        public int Id { get; private set; }

        public string Body { get; private set; } = default!;

        public int TopicId { get; private set; }

        public DateTime DateCreated { get; private set; }

        public bool IsRemoved { get; private set; }

        public int RemovedBy { get; private set; }

        public DateTime? DateRemoved { get; private set; }

        //
        // Navigation Properties

        public TopicEntity Topic { get; set; } = default!;

        public void Remove(int userId)
        {
            IsRemoved = true;
            DateRemoved = DateTime.UtcNow;
            RemovedBy = userId;
        }
    }
}
