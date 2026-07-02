using Herba.Context;

namespace Herba.Seeders
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            BlogCategorySeeder.Seed(context);
            AboutSeeder.Seed(context);
        }
    }
}
