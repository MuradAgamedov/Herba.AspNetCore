using Herba.Entities.About;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.About
{
    public class AboutConfiguration : IEntityTypeConfiguration<Herba.Entities.About.About>
    {
        public void Configure(EntityTypeBuilder<Herba.Entities.About.About> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Image)
                .HasMaxLength(500);

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.About)
                .HasForeignKey(x => x.AboutId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
