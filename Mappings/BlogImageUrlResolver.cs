using AutoMapper;
using Microsoft.Extensions.Configuration;
using Herba.Entities.Blog;
using Herba.Dtos.Blog.Post;

namespace Herba.Mappings
{
    public class BlogImageUrlResolver : IValueResolver<Blog, ResultBlogDto, string?>
    {
        private readonly IConfiguration _configuration;

        public BlogImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? Resolve(Blog source, ResultBlogDto destination, string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Image))
                return null;

            var baseUrl = _configuration["AppSettings:BaseUrl"];
            return $"{baseUrl}{source.Image}";
        }
    }
}