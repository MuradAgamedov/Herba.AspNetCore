namespace Herba.Dtos.Aim.Translation
{
    public class ResultAimTranslationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? IconAltText { get; set; }
        public string LanguageCode { get; set; }
        public int AimId { get; set; }
    }
}
