namespace Herba.Entities.BlogCategory
{
    public class BlogCategoryTranslation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCode { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
    }
}
