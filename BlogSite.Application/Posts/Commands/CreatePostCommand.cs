using BlogSite.Application.Posts.Models;
using MediatR;

namespace BlogSite.Application.Posts.Commands
{
    public sealed class CreatePostCommand : IRequest<CreatePostResponse>, IApplicationRequest
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IUserContext User { get; set; }
    }
}
