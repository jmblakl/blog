using BlogSite.Application.Posts.Models;
using BlogSite.Common;
using BlogSite.Domain;
using BlogSite.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogSite.Application.Posts.Commands
{
    public sealed class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostResponse>
    {
        private readonly BlogSiteDBContext _Context;
        private readonly IDateTimeOffset _DateTimeOffset;
        public CreatePostCommandHandler(BlogSiteDBContext context, IDateTimeOffset dateTimeOffset)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));

            _DateTimeOffset = dateTimeOffset ?? throw new ArgumentNullException(nameof(dateTimeOffset));
        }

        public async Task<CreatePostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            Blog blog = await _Context.Blogs.Where(b => b.Id == request.BlogId).SingleOrDefaultAsync(cancellationToken);
            var post = new Post()
            {
                Content = request.Content,
                Title = request.Title,
                LastModifiedDate = _DateTimeOffset.UtcNow,
                CreatedDate = _DateTimeOffset.UtcNow
            };
            blog.Posts.Add(post);

            await _Context.SaveChangesAsync(cancellationToken);

            return new CreatePostResponse()
            {
                PostId = post.Id,
                BlogId = blog.Id
            };
        }
    }
}
