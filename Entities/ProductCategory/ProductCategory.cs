namespace Herba.Entities.ProductCategory
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string? Icon { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ProductCategoryTranslation> Translations { get; set; }
    }
}
