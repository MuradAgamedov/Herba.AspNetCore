using Herba.Entities;
using Herba.Entities.BlogCategory;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Herba.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogCategoryTranslation> BlogCategoryTranslations { get; set; }
    }
}
