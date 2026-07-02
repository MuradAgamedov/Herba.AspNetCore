using AutoMapper;
using Microsoft.Extensions.Configuration;
using Herba.Entities.Product;
using Herba.Dtos.Product.Item;

namespace Herba.Mappings
{
    public class ProductHoverImageUrlResolver<TDestination> : IValueResolver<Product, TDestination, string?>
    {
        private readonly IConfiguration _configuration;

        public ProductHoverImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? Resolve(Product source, TDestination destination, string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.HoverImage))
                return null;

            var baseUrl = _configuration["AppSettings:BaseUrl"];
            return $"{baseUrl}{source.HoverImage}";
        }
    }
}
