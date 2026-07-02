using Herba.Context;
using Herba.Entities.BlogCategory;
using Microsoft.EntityFrameworkCore;

namespace Herba.Seeders
{
    public static class BlogCategorySeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.BlogCategories.Any())
                return;

            var categories = new List<BlogCategory>
            {
                new()
                {
                    Order = 0,
                    Status = true,
                    Translations = new List<BlogCategoryTranslation>
                    {
                        new() { LanguageCode = "az", Name = "Kilo nəzarəti" },
                        new() { LanguageCode = "en", Name = "Weight Management" }
                    }
                },
                new()
                {
                    Order = 1,
                    Status = true,
                    Translations = new List<BlogCategoryTranslation>
                    {
                        new() { LanguageCode = "az", Name = "Sağlam qidalanma" },
                        new() { LanguageCode = "en", Name = "Healthy Nutrition" }
                    }
                },
                new()
                {
                    Order = 2,
                    Status = true,
                    Translations = new List<BlogCategoryTranslation>
                    {
                        new() { LanguageCode = "az", Name = "İdman qidalanması" },
                        new() { LanguageCode = "en", Name = "Sports Nutrition" }
                    }
                },
                new()
                {
                    Order = 3,
                    Status = true,
                    Translations = new List<BlogCategoryTranslation>
                    {
                        new() { LanguageCode = "az", Name = "Arıqlama" },
                        new() { LanguageCode = "en", Name = "Weight Loss" }
                    }
                }
            };

            context.BlogCategories.AddRange(categories);
            context.SaveChanges();
        }
    }
}