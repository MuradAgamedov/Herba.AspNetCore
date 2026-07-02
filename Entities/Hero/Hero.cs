namespace Herba.Entities.Hero
{
    public class Hero
    {
        public int Id { get; set; }
        public ICollection<HeroTranslation> Translations { get; set; }
    }
}
