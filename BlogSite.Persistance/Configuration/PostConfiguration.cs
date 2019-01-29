using BlogSite.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Persistance.Configuration
{
    internal sealed class PostConfiguration : BaseEntityConfiguration<Post>
    {
        protected override void ConfigureInternal(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.HasOne(p => p.Blog)
                .WithMany(p => p.Posts);
        }
    }
}
