using BlogSite.Application.Blogs.Models;
using BlogSite.Application.Exceptions;
using BlogSite.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogSite.Application.Blogs.Queries
{
    public sealed class GetBlogDetailsQueryHandler : IRequestHandler<GetBlogDetailsQuery, BlogDetails>
    {
        private readonly BlogSiteDBContext _Context;
        public GetBlogDetailsQueryHandler(BlogSiteDBContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<BlogDetails> Handle(GetBlogDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var blog = await _Context.Blogs
                .Include(b => b.Posts)
                .Select(b=> new
                {
                    b.Id,
                    b.Name,
                    b.Url,
                    b.CreatedDate,
                    b.LastModifiedDate,
                    Posts = b.Posts.Select(p => new
                    {
                        p.Id,
                        p.Title,
                        p.CreatedDate
                    })
                })
                .SingleOrDefaultAsync(b => b.Id == request.BlogId, cancellationToken);

            if (blog == null)
                throw new ItemNotFoundException(nameof(blog));

            return new BlogDetails(
                blog.Id,
                blog.Name,
                blog.Url,
                blog.CreatedDate,
                blog.LastModifiedDate,
                blog.Posts.Select(p => new BlogPostPreview(p.Id, blog.Id, p.Title, p.CreatedDate)).ToList());            
        }
    }
}
