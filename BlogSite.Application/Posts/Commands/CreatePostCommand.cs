using BlogSite.Application.Posts.Models;
using MediatR;

namespace BlogSite.Application.Posts.Commands
{
    public sealed class CreatePostCommand : IRequest<CreatePostResponse>
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        
    }
}
