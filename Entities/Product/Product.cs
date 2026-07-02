namespace Herba.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public int ProductCategoryId { get; set; }
        public Herba.Entities.ProductCategory.ProductCategory ProductCategory { get; set; }
        public string? Image { get; set; }
        public string? HoverImage { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<ProductTranslation> Translations { get; set; }
    }
}
