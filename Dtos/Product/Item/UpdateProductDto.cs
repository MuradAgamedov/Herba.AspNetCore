using Herba.Dtos.Product.Translation;
using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.Product.Item
{
    public class UpdateProductDto
    {
        [Required]
        public string Slug { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        public IFormFile? ImageFile { get; set; }
        public IFormFile? HoverImageFile { get; set; }
        [Required]
        public bool Status { get; set; }
        public ICollection<UpdateProductTranslationDto> Translations { get; set; }
    }
}
