using Herba.Dtos.Common;

namespace Herba.Dtos.Product.Item
{
    public class ProductFilterDto : PaginationDto
    {
        public string? Search { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}
