using Herba.Entities.FeaturedProduct;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.FeaturedProduct
{
    public class FeaturedProductConfiguration : IEntityTypeConfiguration<Herba.Entities.FeaturedProduct.FeaturedProduct>
    {
        public void Configure(EntityTypeBuilder<Herba.Entities.FeaturedProduct.FeaturedProduct> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.HasIndex(x => x.ProductId)
                .IsUnique();

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
