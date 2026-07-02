using Herba.Entities.Analysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Analysis
{
    public class AnalysisConfiguration : IEntityTypeConfiguration<Herba.Entities.Analysis.Analysis>
    {
        public void Configure(EntityTypeBuilder<Herba.Entities.Analysis.Analysis> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Icon)
                .HasMaxLength(500);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.Analysis)
                .HasForeignKey(x => x.AnalysisId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
