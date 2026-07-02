namespace Herba.Entities.Blog
{
    public class Blog
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public int? ReadMinutes { get; set; }
        public DateTime PublishedAt { get; set; }
        public string? Image { get; set; }
        public bool Status { get; set; }
        public ICollection<BlogTranslation> Translations { get; set; }
    }
}
