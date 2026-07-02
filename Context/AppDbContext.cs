using Herba.Entities;
using Herba.Entities.About;
using Herba.Entities.Aim;
using Herba.Entities.Analysis;
using Herba.Entities.Blog;
using Herba.Entities.BlogCategory;
using Herba.Entities.FeaturedProduct;
using Herba.Entities.FooterCategory;
using Herba.Entities.Hero;
using Herba.Entities.Product;
using Herba.Entities.ProductCategory;
using Herba.Entities.Testimonial;
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

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductCategoryTranslation> ProductCategoryTranslations { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }

        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutTranslation> AboutTranslations { get; set; }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<HeroTranslation> HeroTranslations { get; set; }

        public DbSet<FeaturedProduct> FeaturedProducts { get; set; }

        public DbSet<FooterCategory> FooterCategories { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<TestimonialTranslation> TestimonialTranslations { get; set; }
    }
}
