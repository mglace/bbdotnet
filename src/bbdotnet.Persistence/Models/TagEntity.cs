namespace bbdotnet.Persistence.Models
{
    public class TagEntity : IEntity
    { 
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        //
        // Navigation Properties

        public ICollection<TopicEntity> Topics { get; set; } = new HashSet<TopicEntity>();
    }
}
