using Herba.Dtos.Hero.Translation;

namespace Herba.Dtos.Hero.Item
{
    public class UpdateHeroDto
    {
        public ICollection<UpdateHeroTranslationDto> Translations { get; set; }
    }
}
