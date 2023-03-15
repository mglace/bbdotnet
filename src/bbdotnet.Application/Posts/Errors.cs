using bbdotnet.Domain.Shared;

namespace bbdotnet.Application;

public static partial class Errors
{
    public static class Posts
    { 
        public static readonly Error NotFound = new("Post.NotFound", "Post not found.");

        public static readonly Error CannotRemoveFirstPost = new("Post.CannotRemoveFirstPost", "Cannot remove the first post of a thread.  Please either clear the flag or remove the entire thread.");
    }
}
