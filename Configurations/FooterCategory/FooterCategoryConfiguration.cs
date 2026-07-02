using Herba.Entities.FooterCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.FooterCategory
{
    public class FooterCategoryConfiguration : IEntityTypeConfiguration<Herba.Entities.FooterCategory.FooterCategory>
    {
        public void Configure(EntityTypeBuilder<Herba.Entities.FooterCategory.FooterCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.HasIndex(x => x.BlogCategoryId)
                .IsUnique();

            builder.HasOne(x => x.BlogCategory)
                .WithMany()
                .HasForeignKey(x => x.BlogCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
