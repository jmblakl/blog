namespace BlogSite.Domain
{
    public sealed class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Blog Blog { get; set; }
    }
}
