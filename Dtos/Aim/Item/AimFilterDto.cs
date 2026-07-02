using Herba.Dtos.Common;

namespace Herba.Dtos.Aim.Item
{
    public class AimFilterDto : PaginationDto
    {
        public string? Search { get; set; }
    }
}
