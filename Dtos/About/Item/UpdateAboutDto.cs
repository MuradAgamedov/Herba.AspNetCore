using Herba.Dtos.About.Translation;

namespace Herba.Dtos.About.Item
{
    public class UpdateAboutDto
    {
        public IFormFile? ImageFile { get; set; }
        public ICollection<UpdateAboutTranslationDto> Translations { get; set; }
    }
}
