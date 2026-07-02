using Herba.Dtos.BlogCategory.Translation;
using Herba.Entities.BlogCategory;

namespace Herba.Dtos.Category
{
    public class ResultBlogCategoryDto
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ResultBlogCategoryTranslationDto> Translations { get; set; }

    }
}
