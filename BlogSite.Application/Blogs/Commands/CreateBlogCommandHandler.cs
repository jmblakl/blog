using BlogSite.Common;
using BlogSite.Persistance;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlogSite.Application.Blogs.Commands
{
    public sealed class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Unit>
    {
        private readonly BlogSiteDBContext _DatabaseContext;
        private readonly IDateTimeOffset _DateTimeOffset;
        public CreateBlogCommandHandler(BlogSiteDBContext databaseContext, IDateTimeOffset datetimeOffset)
        {
            _DatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
            _DateTimeOffset = datetimeOffset ?? throw new ArgumentNullException(nameof(datetimeOffset));
        }

        public async Task<Unit> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            _DatabaseContext.Blogs.Add(new Domain.Blog()
            {
                Name = request.Name,
                CreatedDate = _DateTimeOffset.UtcNow,
                LastModifiedDate = _DateTimeOffset.UtcNow,
                Url = request.Url
            });

            await _DatabaseContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
