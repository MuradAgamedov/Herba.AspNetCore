namespace Herba.Entities.BlogCategory
{
    public class BlogCategory
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<BlogCategoryTranslation> Translations { get;set; }
    }
}
