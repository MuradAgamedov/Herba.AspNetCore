using AutoMapper;
using Herba.Dtos.FooterCategory.Item;
using Herba.Entities.FooterCategory;

namespace Herba.Mappings
{
    public class FooterCategoryMappingProfile : Profile
    {
        public FooterCategoryMappingProfile()
        {
            CreateMap<ResultFooterCategoryDto, FooterCategory>().ReverseMap();
            CreateMap<CreateFooterCategoryDto, FooterCategory>().ReverseMap();
        }
    }
}
