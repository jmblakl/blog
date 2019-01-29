using MediatR;

namespace BlogSite.Application.Blogs.Commands
{
    public sealed class CreateBlogCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Url { get; set;  }
        
    }
}
