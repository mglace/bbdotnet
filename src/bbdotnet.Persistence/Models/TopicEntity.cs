using Microsoft.EntityFrameworkCore;

namespace bbdotnet.Persistence.Models
{
    public class TopicEntity : IEntity
    {
        private TopicEntity() { }

        public TopicEntity(string title, string body, int categoryId, DateTime timestamp) 
        { 
            Title = title;
            CategoryId = categoryId;
            DateCreated = timestamp;

            _replies = new HashSet<PostEntity>();

            AddReply(body, timestamp);
        }

        public int Id { get; private set; }

        public string Title { get; private set; } = default!;

        public int PostCount { get; private set; } = 0;

        public DateTime? DateOfLastPost { get; private set; } = default!;

        public int CategoryId { get; private set; }

        public DateTime DateCreated { get; private set; }

        public byte[]? Timestamp { get; private set; }

        public bool IsRemoved { get; private set; }

        public int? RemovedBy { get; private set; }

        public DateTime? DateRemoved { get; private set; }

        public bool IsClosed { get; private set; }

        //
        // Navigation properties

        public ICollection<TagEntity> Tags { get; set; } = new HashSet<TagEntity>();

        private readonly HashSet<PostEntity> _replies;

        public IEnumerable<PostEntity>? Replies => _replies?.ToArray();

        public PostEntity AddReply(string body, DateTime timestamp, BBDotnetDbContext? dbContext = null)
        { 
            PostEntity post;

            if (_replies != null)
            {
                post = new PostEntity(body, timestamp);

                _replies.Add(post);
            }
            else if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext), "You must provide a dbContext if Replies is not pre-populated");
            }
            else if (dbContext.Entry(this).IsKeySet)
            {
                post = new PostEntity(body, timestamp, Id);

                 dbContext.Posts.Add(post); 
            }
            else 
            {
                throw new Exception("Failed to create new topic reply");
            }

            PostCount += 1;
            DateOfLastPost = timestamp;

            return post;
        }

        public void Remove(int currentUserId)
        {
            IsRemoved = true;
            RemovedBy = currentUserId;
            DateRemoved = DateTime.UtcNow;

            Close();
        }

        public void Close()
        {
            IsClosed = true;
        }

        //public void Archive(int currentUserId)
        //{
        //    IsArchived = true;
        //}
    }
}
