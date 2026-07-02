using AutoMapper;
using Herba.Dtos.Product.Item;
using Herba.Dtos.Product.Translation;
using Herba.Entities.Product;

namespace Herba.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ResultProductDto, Product>().ReverseMap()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<ProductImageUrlResolver<ResultProductDto>>())
                .ForMember(dest => dest.HoverImageUrl, opt => opt.MapFrom<ProductHoverImageUrlResolver<ResultProductDto>>());
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<GetByIdProductDto, Product>().ReverseMap().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<ProductImageUrlResolver<GetByIdProductDto>>())
                .ForMember(dest => dest.HoverImageUrl, opt => opt.MapFrom<ProductHoverImageUrlResolver<GetByIdProductDto>>());
            CreateMap<ProductFilterDto, Product>().ReverseMap();

            CreateMap<ResultProductTranslationDto, ProductTranslation>().ReverseMap();
            CreateMap<UpdateProductTranslationDto, ProductTranslation>().ReverseMap();
        }
    }
}
