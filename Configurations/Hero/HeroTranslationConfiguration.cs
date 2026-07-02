using Herba.Entities.Hero;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Hero
{
    public class HeroTranslationConfiguration : IEntityTypeConfiguration<HeroTranslation>
    {
        public void Configure(EntityTypeBuilder<HeroTranslation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Badge).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PrimaryButtonText).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SecondaryButtonText).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TrustBadge1).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TrustBadge2).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TrustBadge3).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SampleResultTitle).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Stat1Label).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Stat1Value).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Stat2Label).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Stat2Value).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Stat3Label).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Stat3Value).IsRequired().HasMaxLength(50);
            builder.Property(x => x.RecommendationText).IsRequired().HasMaxLength(500);

            builder.Property(x => x.LanguageCode).IsRequired().HasMaxLength(10);

            builder.HasIndex(x => new { x.HeroId, x.LanguageCode })
                .IsUnique();
        }
    }
}
