using System;

namespace BlogSite.Application.Blogs.Models
{
    public sealed class BlogPostPreview
    {
        public BlogPostPreview(int id, int blogId, string title, DateTimeOffset date)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));
            Id = id;
            Title = title;
            Date = date;
            BlogId = blogId;
        }

        public int Id { get; }
        public int BlogId { get; }
        public string Title { get; }
        public DateTimeOffset Date { get; }
    }
}
