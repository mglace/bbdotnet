using Microsoft.EntityFrameworkCore;

namespace bbdotnet.Persistence.Models
{
    public class TopicEntity : IEntity
    {
        private TopicEntity() { }

        public TopicEntity(string title, string body)
        {
            Title = title;

            _replies = new HashSet<PostEntity>();

            AddReply(body);
        }

        public int Id { get; private set; }

        public string Title { get; private set; } = default!;

        public int CategoryId { get; private set; }

        //
        // Navigation properties

        private readonly HashSet<PostEntity>? _replies;

        public IEnumerable<PostEntity>? Replies => _replies?.ToArray();

        public void AddReply(string body, DbContext? dbContext = null)
        {
            if (_replies != null)
            { 
                _replies.Add(new PostEntity(body));
            }
            else if (dbContext == null)
            { 
                throw new ArgumentNullException(nameof(dbContext), "You must provide an instance a DbContext if the Replies collection is not initialized.");
            }
            else if (dbContext.Entry(this).IsKeySet)
            {
                dbContext.Add(new PostEntity(body, Id));
            }
            else
            {
                throw new InvalidOperationException("Could not add a new reply");
            }
        }
    }
}
