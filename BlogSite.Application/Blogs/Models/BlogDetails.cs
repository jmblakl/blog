using System;
using System.Collections.Generic;

namespace BlogSite.Application.Blogs.Models
{
    public sealed class BlogDetails
    {
        public BlogDetails(int id, string name, string url,DateTimeOffset created, DateTimeOffset lastMod, ICollection<BlogPostPreview> posts)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(name));
            Id = id;
            Name = name;
            Url = url;
            Posts = posts ?? new List<BlogPostPreview>();
            Created = created;
            LastModified = lastMod;
        }

        public int Id { get; }
        public string Name { get; }
        public string Url { get; }
        public DateTimeOffset Created { get; }
        public DateTimeOffset LastModified { get; }
        public ICollection<BlogPostPreview> Posts { get; }
    }
}
