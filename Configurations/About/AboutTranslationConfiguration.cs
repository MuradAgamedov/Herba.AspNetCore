using Herba.Entities.About;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.About
{
    public class AboutTranslationConfiguration : IEntityTypeConfiguration<AboutTranslation>
    {
        public void Configure(EntityTypeBuilder<AboutTranslation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.ImageAltText)
                .HasMaxLength(255);

            builder.Property(x => x.LanguageCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => new { x.AboutId, x.LanguageCode })
                .IsUnique();
        }
    }
}
