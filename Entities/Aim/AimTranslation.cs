namespace Herba.Entities.Aim
{
    public class AimTranslation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? IconAltText { get; set; }
        public string LanguageCode { get; set; }
        public int AimId { get; set; }
        public Aim Aim { get; set; }
    }
}
