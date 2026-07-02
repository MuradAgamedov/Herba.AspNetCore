using Herba.Entities.BlogCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations
{
    public class BlogCategoryTranslationConfiguration : IEntityTypeConfiguration<BlogCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<BlogCategoryTranslation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LanguageCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => new
            {
                x.BlogCategoryId,
                x.LanguageCode
            })
            .IsUnique();
        }
    }
}