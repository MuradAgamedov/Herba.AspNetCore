using Herba.Dtos.Hero.Translation;

namespace Herba.Dtos.Hero.Item
{
    public class ResultHeroDto
    {
        public int Id { get; set; }
        public ICollection<ResultHeroTranslationDto> Translations { get; set; }
    }
}
