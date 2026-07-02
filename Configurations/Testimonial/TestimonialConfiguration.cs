using Herba.Entities.Testimonial;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Testimonial
{
    public class TestimonialConfiguration : IEntityTypeConfiguration<Herba.Entities.Testimonial.Testimonial>
    {
        public void Configure(EntityTypeBuilder<Herba.Entities.Testimonial.Testimonial> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CustomerName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Rating)
                .IsRequired();

            builder.Property(x => x.Order)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.Testimonial)
                .HasForeignKey(x => x.TestimonialId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
