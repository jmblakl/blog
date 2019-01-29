using BlogSite.Application.Exceptions;
using BlogSite.Application.Posts.Models;
using BlogSite.Domain;
using BlogSite.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogSite.Application.Posts.Queries
{
    public sealed class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostDetails>
    {
        private readonly BlogSiteDBContext _Context;

        public GetPostQueryHandler(BlogSiteDBContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PostDetails> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            Post post = await _Context.Posts
                .Where(p => p.Blog.Id == request.BlogId)
                .Where(p => p.Id == request.PostId)
                .SingleOrDefaultAsync(cancellationToken);

            if (post == null)
                throw new ItemNotFoundException(nameof(post));

            return new PostDetails()
            {
                PostId = post.Id,
                BlogId = request.BlogId,
                Content = post.Content,
                Created = post.CreatedDate,
                LastModified = post.LastModifiedDate,
                Title = post.Title
            };
        }
    }
}
