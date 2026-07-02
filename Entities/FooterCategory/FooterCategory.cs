namespace Herba.Entities.FooterCategory
{
    public class FooterCategory
    {
        public int Id { get; set; }
        public int BlogCategoryId { get; set; }
        public Herba.Entities.BlogCategory.BlogCategory BlogCategory { get; set; }
        public int Order { get; set; }
    }
}
