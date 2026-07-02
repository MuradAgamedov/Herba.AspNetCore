using Herba.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Blog
{
    public class BlogTranslationConfiguration : IEntityTypeConfiguration<BlogTranslation>
    {
        public void Configure(EntityTypeBuilder<BlogTranslation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.ShortDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Author)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(x => x.SeoTitle)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(x => x.SeoKeywords)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.SeoDescription)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.ImageAltText)
                .HasMaxLength(255);

            builder.HasIndex(x => x.BlogId);

            builder.Property(x => x.LanguageCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => new { x.BlogId, x.LanguageCode })
                .IsUnique();
        }
    }
}