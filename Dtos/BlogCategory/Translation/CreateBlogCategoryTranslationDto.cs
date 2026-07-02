using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.BlogCategory.Translation
{
    public class CreateBlogCategoryTranslationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LanguageCode { get; set; }
        [Required]
        public int BlogCategoryId { get; set; }
    }
}
