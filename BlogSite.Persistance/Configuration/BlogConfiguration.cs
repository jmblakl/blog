using BlogSite.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Persistance.Configuration
{
    internal sealed class BlogConfiguration : BaseEntityConfiguration<Blog>
    {
        protected override void ConfigureInternal(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(b => b.Url)
                .IsRequired();
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasMany(b => b.Posts)
                .WithOne(p => p.Blog);
        }
    }
}
