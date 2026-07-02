
using Herba.Context;
using Herba.Entities;
using Herba.Repositories.Aim;
using Herba.Repositories.Analysis;
using Herba.Repositories.Auth;
using Herba.Repositories.Blog;
using Herba.Repositories.BlogCategory;
using Herba.Repositories.Product;
using Herba.Repositories.ProductCategory;
using Herba.Seeders;
using Herba.Services.Aim;
using Herba.Services.Analysis;
using Herba.Services.Auth;
using Herba.Services.Blog;
using Herba.Services.BlogCategory;
using Herba.Services.File;
using Herba.Services.Files;
using Herba.Services.Product;
using Herba.Services.ProductCategory;
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
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();
            builder.Services.AddScoped<IBlogService, BlogService>();
            builder.Services.AddScoped<IAimRepository, AimRepository>();
            builder.Services.AddScoped<IAimService, AimService>();
            builder.Services.AddScoped<IAnalysisRepository, AnalysisRepository>();
            builder.Services.AddScoped<IAnalysisService, AnalysisService>();
            builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IFileService, FileService>();
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
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
