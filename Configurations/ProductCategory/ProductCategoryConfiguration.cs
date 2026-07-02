using Herba.Entities.ProductCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.ProductCategory
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<Herba.Entities.ProductCategory.ProductCategory>
    {
        public void Configure(EntityTypeBuilder<Herba.Entities.ProductCategory.ProductCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(x => x.Slug)
                .IsUnique();

            builder.Property(x => x.Icon)
                .HasMaxLength(20);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.ProductCategory)
                .HasForeignKey(x => x.ProductCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
