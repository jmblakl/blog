using BlogSite.Application.Posts.Models;
using MediatR;

namespace BlogSite.Application.Posts.Queries
{
    public sealed class GetPostQuery : IRequest<PostDetails>
    {
        public int BlogId { get; set; }

        public int PostId { get; set; }

        
    }
}
