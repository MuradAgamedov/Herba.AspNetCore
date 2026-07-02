using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.FooterCategory.Item
{
    public class CreateFooterCategoryDto
    {
        [Required]
        public int BlogCategoryId { get; set; }
    }
}
