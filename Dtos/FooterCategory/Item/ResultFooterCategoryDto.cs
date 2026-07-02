using Herba.Dtos.Category;

namespace Herba.Dtos.FooterCategory.Item
{
    public class ResultFooterCategoryDto
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int BlogCategoryId { get; set; }
        public ResultBlogCategoryDto BlogCategory { get; set; }
    }
}
