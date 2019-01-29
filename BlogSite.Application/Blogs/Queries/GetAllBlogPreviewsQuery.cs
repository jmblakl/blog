using BlogSite.Application.Blogs.Models;
using MediatR;
using System.Collections.Generic;

namespace BlogSite.Application.Blogs.Queries
{
    public sealed class GetAllBlogPreviewsQuery : IRequest<IEnumerable<BlogPreview>>, IApplicationRequest
    {
        public IUserContext User { get; set; }
    }
}
