using AutoMapper;
using Microsoft.Extensions.Configuration;
using Herba.Entities.Blog;

namespace Herba.Mappings
{
    public class BlogImageUrlResolver<TDestination> : IValueResolver<Blog, TDestination, string?>
    {
        private readonly IConfiguration _configuration;

        public BlogImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? Resolve(Blog source, TDestination destination, string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Image))
                return null;

            var baseUrl = _configuration["AppSettings:BaseUrl"];
            return $"{baseUrl}{source.Image}";
        }
    }
}