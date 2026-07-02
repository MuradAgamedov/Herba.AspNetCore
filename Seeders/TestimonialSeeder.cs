using Herba.Context;
using Herba.Entities.Testimonial;

namespace Herba.Seeders
{
    public static class TestimonialSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Testimonials.Any())
                return;

            var testimonials = new List<Testimonial>
            {
                new()
                {
                    CustomerName = "Leyla Əliyeva",
                    Rating = 5,
                    Order = 0,
                    Status = true,
                    Translations = new List<TestimonialTranslation>
                    {
                        new()
                        {
                            LanguageCode = "az",
                            Quote = "3 ayda 8 kq arıqladım və özümü çox daha enerjili hiss edirəm. AI analiz mənə düzgün başlanğıc nöqtəsi verdi.",
                            Role = "Formula 1 istifadəçisi"
                        }
                    }
                },
                new()
                {
                    CustomerName = "Rəşad Quliyev",
                    Rating = 5,
                    Order = 1,
                    Status = true,
                    Translations = new List<TestimonialTranslation>
                    {
                        new()
                        {
                            LanguageCode = "az",
                            Quote = "Rebuild Strength məşqdən sonrakı bərpamı xeyli sürətləndirdi. Nəticələri 2 həftədə hiss etdim.",
                            Role = "İdmançı"
                        }
                    }
                },
                new()
                {
                    CustomerName = "Səbinə Hüseynova",
                    Rating = 4,
                    Order = 2,
                    Status = true,
                    Translations = new List<TestimonialTranslation>
                    {
                        new()
                        {
                            LanguageCode = "az",
                            Quote = "AI Üz Baxımı Analizi mənə dəri tipimi dəqiq müəyyən etməyə kömək etdi, tövsiyə olunan məhsullar həqiqətən işlədi.",
                            Role = "Üz baxımı müştərisi"
                        }
                    }
                },
                new()
                {
                    CustomerName = "Tural Məmmədov",
                    Rating = 5,
                    Order = 3,
                    Status = true,
                    Translations = new List<TestimonialTranslation>
                    {
                        new()
                        {
                            LanguageCode = "az",
                            Quote = "Arıq bədən quruluşum var idi, Formula 1 və protein qarışığı ilə 4 ayda sağlam şəkildə kilo aldım.",
                            Role = "Kilo alma proqramı"
                        }
                    }
                }
            };

            context.Testimonials.AddRange(testimonials);
            context.SaveChanges();
        }
    }
}
