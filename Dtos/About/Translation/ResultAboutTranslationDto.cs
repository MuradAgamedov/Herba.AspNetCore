namespace Herba.Dtos.About.Translation
{
    public class ResultAboutTranslationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageAltText { get; set; }
        public string LanguageCode { get; set; }
        public int AboutId { get; set; }
    }
}
