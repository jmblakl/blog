using BlogSite.Application.Posts.Models;
using MediatR;

namespace BlogSite.Application.Posts.Queries
{
    public sealed class GetPostQuery : IRequest<PostDetails>, IApplicationRequest
    {
        public int BlogId { get; set; }

        public int PostId { get; set; }

        public IUserContext User { get; set; }
    }
}
