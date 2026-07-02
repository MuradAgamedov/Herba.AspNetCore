using Herba.Dtos.BlogCategory.Translation;
using Herba.Entities.BlogCategory;
using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.BlogCategory.Category
{
    public class CreateBlogCategoryDto
    {
        [Required]
        public bool Status { get; set; }
        [Required]
        public ICollection<UpdateBlogCategoryTranslationDto> Translations { get; set; }
    }
}
