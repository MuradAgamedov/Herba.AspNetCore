using Herba.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Product
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.ShortDescription)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.ImageAltText)
                .HasMaxLength(255);

            builder.Property(x => x.HoverImageAltText)
                .HasMaxLength(255);

            builder.Property(x => x.LanguageCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => new { x.ProductId, x.LanguageCode })
                .IsUnique();
        }
    }
}
