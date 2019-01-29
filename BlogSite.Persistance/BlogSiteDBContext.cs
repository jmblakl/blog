using BlogSite.Domain;
using BlogSite.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Persistance
{
    public class BlogSiteDBContext : DbContext
    {
        public BlogSiteDBContext(DbContextOptions<BlogSiteDBContext> options) 
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }
    }
}
