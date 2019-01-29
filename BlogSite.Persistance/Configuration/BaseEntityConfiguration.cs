using BlogSite.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSite.Persistance.Configuration
{
    internal abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity, new()
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.Id);
            builder.Property(e => e.LastModifiedDate);
            builder.Property(e => e.CreatedDate);
            ConfigureInternal(builder);
        }

        protected abstract void ConfigureInternal(EntityTypeBuilder<TEntity> builder);
    }
}
