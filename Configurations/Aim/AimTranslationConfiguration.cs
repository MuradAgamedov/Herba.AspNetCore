using Herba.Entities.Aim;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Aim
{
    public class AimTranslationConfiguration : IEntityTypeConfiguration<AimTranslation>
    {
        public void Configure(EntityTypeBuilder<AimTranslation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IconAltText)
                .HasMaxLength(255);

            builder.Property(x => x.LanguageCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => new { x.AimId, x.LanguageCode })
                .IsUnique();
        }
    }
}
