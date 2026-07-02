using AutoMapper;
using Herba.Dtos.FeaturedProduct.Item;
using Herba.Entities.FeaturedProduct;

namespace Herba.Mappings
{
    public class FeaturedProductMappingProfile : Profile
    {
        public FeaturedProductMappingProfile()
        {
            CreateMap<ResultFeaturedProductDto, FeaturedProduct>().ReverseMap();
            CreateMap<CreateFeaturedProductDto, FeaturedProduct>().ReverseMap();
        }
    }
}
