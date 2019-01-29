using System;

namespace BlogSite.Application.Blogs.Models
{
    public sealed class BlogPreview
    {
        public BlogPreview(int blogId, string name, string url, int numberOfPosts, DateTimeOffset postingSince)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));
            if (numberOfPosts < 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfPosts));

            BlogId = blogId;
            Name = name;
            Url = url;
            NumberOfPosts = numberOfPosts;
            PostingSince = postingSince;
        }

        public int BlogId { get; }
        public string Name { get; }
        public string Url { get; }
        public int NumberOfPosts { get; }
        public DateTimeOffset PostingSince { get; }
    }
}
