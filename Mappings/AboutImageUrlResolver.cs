using AutoMapper;
using Microsoft.Extensions.Configuration;
using Herba.Entities.About;
using Herba.Dtos.About.Item;

namespace Herba.Mappings
{
    public class AboutImageUrlResolver : IValueResolver<About, ResultAboutDto, string?>
    {
        private readonly IConfiguration _configuration;

        public AboutImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? Resolve(About source, ResultAboutDto destination, string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Image))
                return null;

            var baseUrl = _configuration["AppSettings:BaseUrl"];
            return $"{baseUrl}{source.Image}";
        }
    }
}
