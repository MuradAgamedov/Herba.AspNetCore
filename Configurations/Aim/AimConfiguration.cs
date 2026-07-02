using Herba.Entities.Aim;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Aim
{
    public class AimConfiguration : IEntityTypeConfiguration<Herba.Entities.Aim.Aim>
    {
        public void Configure(EntityTypeBuilder<Herba.Entities.Aim.Aim> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Icon)
                .HasMaxLength(500);

            builder.Property(x => x.Order)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.Aim)
                .HasForeignKey(x => x.AimId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
