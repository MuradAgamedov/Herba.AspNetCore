namespace Herba.Entities.Hero
{
    public class HeroTranslation
    {
        public int Id { get; set; }
        public string Badge { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PrimaryButtonText { get; set; }
        public string SecondaryButtonText { get; set; }
        public string TrustBadge1 { get; set; }
        public string TrustBadge2 { get; set; }
        public string TrustBadge3 { get; set; }
        public string SampleResultTitle { get; set; }
        public string Stat1Label { get; set; }
        public string Stat1Value { get; set; }
        public string Stat2Label { get; set; }
        public string Stat2Value { get; set; }
        public string Stat3Label { get; set; }
        public string Stat3Value { get; set; }
        public string RecommendationText { get; set; }
        public string LanguageCode { get; set; }
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
    }
}
