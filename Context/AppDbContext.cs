using Herba.Entities;
using Herba.Entities.Aim;
using Herba.Entities.Analysis;
using Herba.Entities.Blog;
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

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogTranslation> BlogTranslations { get; set; }

        public DbSet<Aim> Aims { get; set; }
        public DbSet<AimTranslation> AimTranslations { get; set; }

        public DbSet<Analysis> Analyses { get; set; }
        public DbSet<AnalysisTranslation> AnalysisTranslations { get; set; }
    }
}
