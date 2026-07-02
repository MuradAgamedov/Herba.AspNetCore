namespace Herba.Entities.Analysis
{
    public class AnalysisTranslation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }
        public string? IconAltText { get; set; }
        public string LanguageCode { get; set; }
        public int AnalysisId { get; set; }
        public Analysis Analysis { get; set; }
    }
}
