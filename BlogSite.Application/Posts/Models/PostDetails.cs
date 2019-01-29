using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSite.Application.Posts.Models
{
    public sealed class PostDetails
    {
        public int BlogId { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }
}
