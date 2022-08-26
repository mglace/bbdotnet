using ErrorOr;

namespace bbdotnet.Application
{
    public static partial class Errors
    {
        public static class Posts
        { 
            public static readonly Error NotFound = Error.NotFound("Post.NotFound", "Post not found.");
            public static readonly Error CannotRemoveFirstPost = Error.NotFound("Post.CannotRemoveFirstPost", "Cannot remove the first post of a thread.  Please either clear the flag or remove the entire thread.");
        }
    }
}
