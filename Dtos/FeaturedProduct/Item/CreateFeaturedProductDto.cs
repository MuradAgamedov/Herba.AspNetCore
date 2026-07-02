using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.FeaturedProduct.Item
{
    public class CreateFeaturedProductDto
    {
        [Required]
        public int ProductId { get; set; }
    }
}
