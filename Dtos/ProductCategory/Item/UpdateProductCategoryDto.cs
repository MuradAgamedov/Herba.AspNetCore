using Herba.Dtos.ProductCategory.Translation;
using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.ProductCategory.Item
{
    public class UpdateProductCategoryDto
    {
        [Required]
        public string Slug { get; set; }
        public string? Icon { get; set; }
        [Required]
        public bool Status { get; set; }
        public ICollection<UpdateProductCategoryTranslationDto> Translations { get; set; }
    }
}
