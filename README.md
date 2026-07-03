# Herba

Herba is an ASP.NET Core 9 Web API backend for a herbal/wellness product website. It exposes REST endpoints for managing site content (hero banners, about section, aims, analyses, blog, testimonials) and a product catalog, backed by SQL Server via Entity Framework Core, with JWT-based authentication and Swagger documentation.

## Tech Stack

- **.NET 9** / ASP.NET Core Web API
- **Entity Framework Core 9** (SQL Server provider)
- **ASP.NET Core Identity** + **JWT Bearer** authentication
- **AutoMapper** for entity ↔ DTO mapping
- **Swashbuckle (Swagger)** for API documentation

## Project Structure

```
Herba/
├── Controllers/       # API endpoints (About, Aim, Analysis, Auth, Blog, BlogCategory,
│                       #   FeaturedProduct, FooterCategory, Hero, Product, ProductCategory, Testimonial)
├── Services/           # Business logic layer
├── Repositories/       # Data access layer
├── Entities/           # EF Core entity models
├── Dtos/                # Request/response data transfer objects
├── Mappings/            # AutoMapper profiles and image URL resolvers
├── Context/             # AppDbContext (EF Core)
├── Migrations/          # EF Core migrations
├── Seeders/              # Initial data seeding (identity roles, hero, about, testimonials, blog categories)
├── Configurations/       # EF Core entity type configurations
└── wwwroot/uploads/       # Uploaded images (about, aims, analyses, blogs, products)
```

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local or remote instance)

### Setup

1. Clone the repository and restore dependencies:
   ```bash
   dotnet restore
   ```

2. Configure your connection string and JWT settings in `Herba/appsettings.json` (or use `appsettings.Development.json` / user secrets for local overrides):
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=Herba;Trusted_Connection=True;TrustServerCertificate=True;"
     },
     "Jwt": {
       "Key": "your-secret-key",
       "Issuer": "HerbaApi",
       "Audience": "HerbaClient",
       "ExpireMinutes": 120
     }
   }
   ```

3. Apply EF Core migrations to create/update the database:
   ```bash
   dotnet ef database update --project Herba
   ```

4. Run the API:
   ```bash
   dotnet run --project Herba
   ```

   On startup, the app automatically seeds initial data (identity roles/users, hero, about, testimonials, blog categories) via `DbSeeder` and `IdentitySeeder`.

5. Browse the Swagger UI (available in Development) at the app's root, e.g. `https://localhost:7137/swagger`.

### Authentication

Most endpoints require a Bearer token. Obtain one via:

```
POST /api/Auth/login
```

Then include it on subsequent requests:

```
Authorization: Bearer <token>
```

### CORS

The API is configured to allow requests from a React frontend running at `http://localhost:5173` (see `AllowReactApp` policy in `Program.cs`). Update this origin if your frontend runs elsewhere.

## License

No license specified.
