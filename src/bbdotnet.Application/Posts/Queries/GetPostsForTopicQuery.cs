using bbdotnet.Application.Common;
using bbdotnet.Application.Posts.Models;

namespace bbdotnet.Application.Posts.Queries
{
    public record GetPostsForTopicQuery : PagedQuery<PostDetailDTO>;
}
