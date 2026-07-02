using Herba.Entities.ProductCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.ProductCategory
{
    public class ProductCategoryTranslationConfiguration : IEntityTypeConfiguration<ProductCategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryTranslation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LanguageCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => new { x.ProductCategoryId, x.LanguageCode })
                .IsUnique();
        }
    }
}
