using BlogSite.Persistance.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Persistance
{
    public sealed class BlogSiteDBContextFactory : DesignTimeDbContextFactoryBase<BlogSiteDBContext>
    {
        protected override BlogSiteDBContext CreateNewInstance(DbContextOptions<BlogSiteDBContext> options)
        {
            return new BlogSiteDBContext(options);
        }
    }
}
