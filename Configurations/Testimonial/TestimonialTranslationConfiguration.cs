using Herba.Entities.Testimonial;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Testimonial
{
    public class TestimonialTranslationConfiguration : IEntityTypeConfiguration<TestimonialTranslation>
    {
        public void Configure(EntityTypeBuilder<TestimonialTranslation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quote)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.Role)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.LanguageCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(x => new { x.TestimonialId, x.LanguageCode })
                .IsUnique();
        }
    }
}
