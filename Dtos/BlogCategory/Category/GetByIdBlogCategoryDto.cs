using Herba.Dtos.BlogCategory.Translation;

namespace Herba.Dtos.BlogCategory.Category
{
    public class GetByIdBlogCategoryDto
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ResultBlogCategoryTranslationDto> Translations { get; set; }
    }
}
