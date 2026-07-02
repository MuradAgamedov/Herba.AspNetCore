using Herba.Entities.Analysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Analysis
{
    public class AnalysisTranslationConfiguration : IEntityTypeConfiguration<AnalysisTranslation>
    {
        public void Configure(EntityTypeBuilder<AnalysisTranslation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.ButtonText)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.IconAltText)
                .HasMaxLength(255);

            builder.Property(x => x.LanguageCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => new { x.AnalysisId, x.LanguageCode })
                .IsUnique();
        }
    }
}
