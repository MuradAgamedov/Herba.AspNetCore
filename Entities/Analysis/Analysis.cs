namespace Herba.Entities.Analysis
{
    public class Analysis
    {
        public int Id { get; set; }
        public string? Icon { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<AnalysisTranslation> Translations { get; set; }
    }
}
