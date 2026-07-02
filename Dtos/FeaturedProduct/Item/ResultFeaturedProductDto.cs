using Herba.Dtos.Product.Item;

namespace Herba.Dtos.FeaturedProduct.Item
{
    public class ResultFeaturedProductDto
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int ProductId { get; set; }
        public ResultProductDto Product { get; set; }
    }
}
