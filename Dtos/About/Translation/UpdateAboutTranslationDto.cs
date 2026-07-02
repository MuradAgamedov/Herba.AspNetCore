namespace Herba.Dtos.About.Translation
{
    public class UpdateAboutTranslationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageAltText { get; set; }
        public string LanguageCode { get; set; }
    }
}
