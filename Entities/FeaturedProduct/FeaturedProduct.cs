namespace Herba.Entities.FeaturedProduct
{
    public class FeaturedProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Herba.Entities.Product.Product Product { get; set; }
        public int Order { get; set; }
    }
}
