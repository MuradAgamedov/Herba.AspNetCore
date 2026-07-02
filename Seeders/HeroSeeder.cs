using Herba.Context;
using Herba.Entities.Hero;

namespace Herba.Seeders
{
    public static class HeroSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Heroes.Any())
                return;

            var hero = new Hero
            {
                Translations = new List<HeroTranslation>
                {
                    new()
                    {
                        LanguageCode = "az",
                        Badge = "🤖 AI Dəstəkli Sağlamlıq Platforması",
                        Title = "Sənə Uyğun Herbalife Planını Kəşf Et",
                        Description = "Boy-çəki, məqsəd və dəri tipinə əsaslanan pulsuz AI analiz ilə sənə xüsusi qidalanma və üz baxımı tövsiyələri al, ekspert konsultasiyası üçün birbaşa WhatsApp-a keç.",
                        PrimaryButtonText = "🤖 AI Analiz Et",
                        SecondaryButtonText = "WhatsApp ilə Danış",
                        TrustBadge1 = "✅ 500+ Məmnun Müştəri",
                        TrustBadge2 = "✅ Pulsuz AI Analiz",
                        TrustBadge3 = "✅ Rəsmi Distribütor",
                        SampleResultTitle = "Nümunə AI Nəticəsi",
                        Stat1Label = "BMI Balansı",
                        Stat1Value = "22.4",
                        Stat2Label = "Nəmləndirmə Ehtiyacı",
                        Stat2Value = "Yüksək",
                        Stat3Label = "Enerji Səviyyəsi Hədəfi",
                        Stat3Value = "Orta-Yüksək",
                        RecommendationText = "Formula 1 + Herbal Aloe tövsiyə olunur"
                    }
                }
            };

            context.Heroes.Add(hero);
            context.SaveChanges();
        }
    }
}
