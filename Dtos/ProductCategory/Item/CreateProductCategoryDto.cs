using Herba.Dtos.ProductCategory.Translation;
using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.ProductCategory.Item
{
    public class CreateProductCategoryDto
    {
        [Required]
        public string Slug { get; set; }
        public string? Icon { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public ICollection<UpdateProductCategoryTranslationDto> Translations { get; set; }
    }
}
