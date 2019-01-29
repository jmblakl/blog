using BlogSite.Application.Blogs.Models;
using MediatR;

namespace BlogSite.Application.Blogs.Queries
{
    public sealed class GetBlogDetailsQuery : IRequest<BlogDetails>
    {
        public int BlogId { get; set; }

        
    }
}
