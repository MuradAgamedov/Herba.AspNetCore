namespace Herba.Entities.About
{
    public class AboutTranslation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageAltText { get; set; }
        public string LanguageCode { get; set; }
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
