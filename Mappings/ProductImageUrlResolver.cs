using AutoMapper;
using Microsoft.Extensions.Configuration;
using Herba.Entities.Product;
using Herba.Dtos.Product.Item;

namespace Herba.Mappings
{
    public class ProductImageUrlResolver<TDestination> : IValueResolver<Product, TDestination, string?>
    {
        private readonly IConfiguration _configuration;

        public ProductImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? Resolve(Product source, TDestination destination, string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Image))
                return null;

            var baseUrl = _configuration["AppSettings:BaseUrl"];
            return $"{baseUrl}{source.Image}";
        }
    }
}
