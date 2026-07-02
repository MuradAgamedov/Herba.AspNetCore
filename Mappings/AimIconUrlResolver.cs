using AutoMapper;
using Microsoft.Extensions.Configuration;
using Herba.Entities.Aim;
using Herba.Dtos.Aim.Item;

namespace Herba.Mappings
{
    public class AimIconUrlResolver : IValueResolver<Aim, ResultAimDto, string?>
    {
        private readonly IConfiguration _configuration;

        public AimIconUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? Resolve(Aim source, ResultAimDto destination, string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Icon))
                return null;

            var baseUrl = _configuration["AppSettings:BaseUrl"];
            return $"{baseUrl}{source.Icon}";
        }
    }
}
