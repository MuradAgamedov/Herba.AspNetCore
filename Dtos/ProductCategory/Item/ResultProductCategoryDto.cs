using Herba.Dtos.ProductCategory.Translation;

namespace Herba.Dtos.ProductCategory.Item
{
    public class ResultProductCategoryDto
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string? Icon { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ResultProductCategoryTranslationDto> Translations { get; set; }
    }
}
