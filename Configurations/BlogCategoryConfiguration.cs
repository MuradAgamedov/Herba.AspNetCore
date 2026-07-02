using Herba.Entities.BlogCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations
{
    public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x=>x.Translations)
                .WithOne(x=>x.BlogCategory)
                .HasForeignKey(x => x.BlogCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Status).HasDefaultValue(true).IsRequired();
        }
    }
}
