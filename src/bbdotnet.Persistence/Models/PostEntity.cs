namespace bbdotnet.Persistence.Models
{
    public class PostEntity : IEntity
    {
        private PostEntity() {  }

        public PostEntity(string body, int topicId = default)
        {
            Body = body;

            TopicId = topicId;
        }

        public int Id { get; private set; }

        public string Body { get; private set; } = default!;

        public int TopicId { get; private set; }

        public DateTime DateCreated { get; private set; }

        //
        // Navigation Properties

        public TopicEntity? Topic { get; private set; }
    }
}
