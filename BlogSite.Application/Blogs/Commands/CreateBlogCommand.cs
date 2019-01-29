using BlogSite.Application.Blogs.Models;
using MediatR;

namespace BlogSite.Application.Blogs.Commands
{
    public sealed class CreateBlogCommand : IRequest<CreateBlogResponse>
    {
        public string Name { get; set; }
        public string Url { get; set;  }
        
    }
}
