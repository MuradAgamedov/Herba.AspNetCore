using Herba.Entities.Hero;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herba.Configurations.Hero
{
    public class HeroConfiguration : IEntityTypeConfiguration<Herba.Entities.Hero.Hero>
    {
        public void Configure(EntityTypeBuilder<Herba.Entities.Hero.Hero> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Translations)
                .WithOne(x => x.Hero)
                .HasForeignKey(x => x.HeroId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
