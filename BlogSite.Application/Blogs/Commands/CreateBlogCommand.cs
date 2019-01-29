using MediatR;

namespace BlogSite.Application.Blogs.Commands
{
    public sealed class CreateBlogCommand : IRequest<Unit>, IApplicationRequest
    {
        public string Name { get; set; }
        public string Url { get; set;  }
        public IUserContext User { get; set; }
    }
}
