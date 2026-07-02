namespace Herba.Entities.Blog
{
    public class BlogTranslation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public string ImageAltText { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public string LanguageCode { get; set; }
    }
}
