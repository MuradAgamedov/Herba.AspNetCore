using AutoMapper;
using Herba.Dtos.ProductCategory.Item;
using Herba.Dtos.ProductCategory.Translation;
using Herba.Entities.ProductCategory;

namespace Herba.Mappings
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ResultProductCategoryDto, ProductCategory>().ReverseMap();
            CreateMap<CreateProductCategoryDto, ProductCategory>().ReverseMap();
            CreateMap<UpdateProductCategoryDto, ProductCategory>().ReverseMap();
            CreateMap<GetByIdProductCategoryDto, ProductCategory>().ReverseMap();
            CreateMap<ProductCategoryFilterDto, ProductCategory>().ReverseMap();

            CreateMap<ResultProductCategoryTranslationDto, ProductCategoryTranslation>().ReverseMap();
            CreateMap<UpdateProductCategoryTranslationDto, ProductCategoryTranslation>().ReverseMap();
        }
    }
}
