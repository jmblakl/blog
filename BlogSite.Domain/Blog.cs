using System.Collections.Generic;

namespace BlogSite.Domain
{
    public class Blog : BaseEntity
    {
        public Blog()
        {
            Posts = new List<Post>();
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public ICollection<Post> Posts { get; private set; }
    }
}
