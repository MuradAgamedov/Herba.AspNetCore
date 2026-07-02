using AutoMapper;
using Microsoft.Extensions.Configuration;
using Herba.Entities.Analysis;
using Herba.Dtos.Analysis.Item;

namespace Herba.Mappings
{
    public class AnalysisIconUrlResolver : IValueResolver<Analysis, ResultAnalysisDto, string?>
    {
        private readonly IConfiguration _configuration;

        public AnalysisIconUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? Resolve(Analysis source, ResultAnalysisDto destination, string? destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Icon))
                return null;

            var baseUrl = _configuration["AppSettings:BaseUrl"];
            return $"{baseUrl}{source.Icon}";
        }
    }
}
