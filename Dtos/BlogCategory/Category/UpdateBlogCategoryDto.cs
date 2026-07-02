using Herba.Dtos.BlogCategory.Translation;
using Herba.Entities.BlogCategory;
using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.BlogCategory.Category
{
    public class UpdateBlogCategoryDto
    {
        [Required]
        public bool Status { get; set; }
        public ICollection<UpdateBlogCategoryTranslationDto> Translations { get; set; }
    }
}
