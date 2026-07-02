using Herba.Dtos.About.Translation;

namespace Herba.Dtos.About.Item
{
    public class ResultAboutDto
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<ResultAboutTranslationDto> Translations { get; set; }
    }
}
