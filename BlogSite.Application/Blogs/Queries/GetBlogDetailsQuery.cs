using BlogSite.Application.Blogs.Models;
using MediatR;

namespace BlogSite.Application.Blogs.Queries
{
    public sealed class GetBlogDetailsQuery : IRequest<BlogDetails>, IApplicationRequest
    {
        public int BlogId { get; set; }

        public IUserContext User { get; set; }
    }
}
