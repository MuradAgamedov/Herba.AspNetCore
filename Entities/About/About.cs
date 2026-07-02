namespace Herba.Entities.About
{
    public class About
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public ICollection<AboutTranslation> Translations { get; set; }
    }
}
