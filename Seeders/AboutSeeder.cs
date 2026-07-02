using Herba.Context;
using Herba.Entities.About;

namespace Herba.Seeders
{
    public static class AboutSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Abouts.Any())
                return;

            var about = new About
            {
                Translations = new List<AboutTranslation>
                {
                    new()
                    {
                        LanguageCode = "az",
                        Title = "Sağlamlıq yolumuz necə başladı",
                        Description = "Bir neçə il əvvəl özüm də enerji çatışmazlığı və qeyri-balanslaşdırılmış qidalanma problemi ilə üzləşmişdim. Herbalife məhsulları ilə tanış olduqdan sonra həyat tərzimi tamamilə dəyişdirdim və bu təcrübəmi başqaları ilə bölüşmək qərarına gəldim.\n\nBu gün yüzlərlə insana fərdi qidalanma və üz baxımı tövsiyələri verərək onların sağlam və özünə güvənli həyat tərzinə keçidində yol yoldaşı oluram. AI dəstəkli analiz alətlərimiz bu prosesi daha da şəffaf və dəqiq edir."
                    }
                }
            };

            context.Abouts.Add(about);
            context.SaveChanges();
        }
    }
}
