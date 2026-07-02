
using Herba.Context;
using Herba.Entities;
using Herba.Repositories.Auth;
using Herba.Repositories.BlogCategory;
using Herba.Seeders;
using Herba.Services.Auth;
using Herba.Services.BlogCategory;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Herba
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(cfg => { }, typeof(Program));
            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
            builder.Services.AddScoped<IBlogCategoryService, BlogCategoryService>();
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                DbSeeder.Seed(context);

                await IdentitySeeder.SeedAsync(
                    scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>(),
                    scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>());
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
