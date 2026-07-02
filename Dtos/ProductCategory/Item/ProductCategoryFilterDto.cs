using Herba.Dtos.Common;

namespace Herba.Dtos.ProductCategory.Item
{
    public class ProductCategoryFilterDto : PaginationDto
    {
        public string? Search { get; set; }
    }
}
