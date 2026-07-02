using Herba.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<Herba.Entities.Product.Product>
    {
        public void Configure(EntityTypeBuilder<Herba.Entities.Product.Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(x => x.Slug)
                .IsUnique();

            builder.Property(x => x.Image)
                .HasMaxLength(500);

            builder.Property(x => x.HoverImage)
                .HasMaxLength(500);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(x => x.ProductCategory)
                .WithMany()
                .HasForeignKey(x => x.ProductCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
