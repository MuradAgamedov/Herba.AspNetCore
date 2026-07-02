using Herba.Dtos.Product.Translation;

namespace Herba.Dtos.Product.Item
{
    public class ResultProductDto
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public int ProductCategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public string? HoverImageUrl { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ResultProductTranslationDto> Translations { get; set; }
    }
}
