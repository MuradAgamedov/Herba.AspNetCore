using Herba.Dtos.Common;

namespace Herba.Dtos.Analysis.Item
{
    public class AnalysisFilterDto : PaginationDto
    {
        public string? Search { get; set; }
    }
}
