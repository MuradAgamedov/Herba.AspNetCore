using Herba.Dtos.Common;

namespace Herba.Dtos.BlogCategory.Category
{
    public class BlogCategoryFilterDto : PaginationDto
    {
        public string? Search { get; set; }
    }
}
