
using Herba.Context;
using Herba.Entities;
using Herba.Repositories.About;
using Herba.Repositories.Aim;
using Herba.Repositories.Analysis;
using Herba.Repositories.Auth;
using Herba.Repositories.Blog;
using Herba.Repositories.BlogCategory;
using Herba.Repositories.FeaturedProduct;
using Herba.Repositories.FooterCategory;
using Herba.Repositories.Hero;
using Herba.Repositories.Product;
using Herba.Repositories.ProductCategory;
using Herba.Repositories.Testimonial;
using Herba.Seeders;
using Herba.Services.About;
using Herba.Services.Aim;
using Herba.Services.Analysis;
using Herba.Services.Auth;
using Herba.Services.Blog;
using Herba.Services.BlogCategory;
using Herba.Services.File;
using Herba.Services.FeaturedProduct;
using Herba.Services.Files;
using Herba.Services.FooterCategory;
using Herba.Services.Hero;
using Herba.Services.Product;
using Herba.Services.ProductCategory;
using Herba.Services.Testimonial;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace Herba
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var jwt = builder.Configuration.GetSection("Jwt");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(cfg => { }, typeof(Program));
            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwt["Issuer"],
                        ValidAudience = jwt["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwt["Key"]!)
                        )
                    };
                });
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddScoped<IAboutRepository, AboutRepository>();
            builder.Services.AddScoped<IAboutService, AboutService>();
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
            builder.Services.AddScoped<IHeroRepository, HeroRepository>();
            builder.Services.AddScoped<IHeroService, HeroService>();
            builder.Services.AddScoped<IFeaturedProductRepository, FeaturedProductRepository>();
            builder.Services.AddScoped<IFeaturedProductService, FeaturedProductService>();
            builder.Services.AddScoped<IFooterCategoryRepository, FooterCategoryRepository>();
            builder.Services.AddScoped<IFooterCategoryService, FooterCategoryService>();
            builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            builder.Services.AddScoped<ITestimonialService, TestimonialService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Tokeni belə yaz: Bearer TOKEN"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
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
            app.UseCors("AllowReactApp");
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
