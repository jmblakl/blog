
using BlogSite.Application.Blogs.Models;
using BlogSite.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Application.Blogs.Queries
{
    public sealed class GetAllBlogPreviewsQueryHandler : IRequestHandler<GetAllBlogPreviewsQuery, IEnumerable<BlogPreview>>
    {
        private readonly BlogSiteDBContext _DatabaseContext;
        public GetAllBlogPreviewsQueryHandler(BlogSiteDBContext databaseContext)
        {
            _DatabaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public async Task<IEnumerable<BlogPreview>> Handle(GetAllBlogPreviewsQuery request, CancellationToken cancellationToken)
        {
            var list = await _DatabaseContext.Blogs                            
                                .Select(b => new
                                {
                                    b.Id,
                                    b.Name,
                                    b.Url,
                                    b.CreatedDate,
                                    Count = b.Posts.Count()
                                }).ToListAsync(cancellationToken);

            return list.Select(item => new BlogPreview(item.Id, item.Name, item.Url, item.Count, item.CreatedDate));
        }
    }
}
