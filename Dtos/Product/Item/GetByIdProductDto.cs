using Herba.Dtos.Product.Translation;

namespace Herba.Dtos.Product.Item
{
    public class GetByIdProductDto
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public int ProductCategoryId { get; set; }
        public string? Image { get; set; }
        public string? HoverImage { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ResultProductTranslationDto> Translations { get; set; }
    }
}
