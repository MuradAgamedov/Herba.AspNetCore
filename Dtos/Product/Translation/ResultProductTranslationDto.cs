namespace Herba.Dtos.Product.Translation
{
    public class ResultProductTranslationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string? ImageAltText { get; set; }
        public string? HoverImageAltText { get; set; }
        public string LanguageCode { get; set; }
        public int ProductId { get; set; }
    }
}
