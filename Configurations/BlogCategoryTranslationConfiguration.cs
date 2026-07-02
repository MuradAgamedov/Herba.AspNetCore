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
            builder.HasOne(x => x.BlogCategory)
                .WithMany(x => x.Translations)
                .HasForeignKey(x => x.BlogCategoryId);
        }
    }
}
