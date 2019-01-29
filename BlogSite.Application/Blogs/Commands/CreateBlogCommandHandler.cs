using BlogSite.Application.Blogs.Models;
using BlogSite.Common;
using BlogSite.Persistance;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlogSite.Application.Blogs.Commands
{
    public sealed class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, CreateBlogResponse>
    {
        private readonly BlogSiteDBContext _DatabaseContext;
        private readonly IDateTimeOffset _DateTimeOffset;
        public CreateBlogCommandHandler(BlogSiteDBContext databaseContext, IDateTimeOffset datetimeOffset)
        {
            _DatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _DateTimeOffset = datetimeOffset ?? throw new ArgumentNullException(nameof(datetimeOffset));
        }

        public async Task<CreateBlogResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Domain.Blog()
            {
                Name = request.Name,
                CreatedDate = _DateTimeOffset.UtcNow,
                LastModifiedDate = _DateTimeOffset.UtcNow,
                Url = request.Url
            };

            _DatabaseContext.Blogs.Add(blog);

            await _DatabaseContext.SaveChangesAsync(cancellationToken);
            return new CreateBlogResponse() { BlogId = blog.Id };
        }
    }
}
