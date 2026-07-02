using Herba.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Blog
{
    public class BlogConfiguration : IEntityTypeConfiguration<Herba.Entities.Blog.Blog>
    {
        public void Configure(EntityTypeBuilder<Herba.Entities.Blog.Blog> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(x => x.Slug)
                .IsUnique();

            builder.Property(x => x.ReadMinutes)
                .IsRequired(false);

            builder.Property(x => x.PublishedAt)
                .IsRequired();

            builder.Property(x => x.Image)
                .HasMaxLength(500);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.Blog)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}