using Herba.Context;
using Herba.Entities;
using Microsoft.AspNetCore.Identity;

namespace Herba.Seeders
{
    public class IdentitySeeder
    {
        public static async Task SeedAsync(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var user = await userManager.FindByEmailAsync("admin@stokflow.com");

            if (user == null)
            {
                user = new AppUser
                {
                    Name = "Murad",
                    SurName = "Agamedov",
                    UserName = "murad98",
                    Email = "agamedov94@mail.ru",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "Admin123*");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
