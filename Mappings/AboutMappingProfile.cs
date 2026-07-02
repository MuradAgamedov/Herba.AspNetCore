using AutoMapper;
using Herba.Dtos.About.Item;
using Herba.Dtos.About.Translation;
using Herba.Entities.About;

namespace Herba.Mappings
{
    public class AboutMappingProfile : Profile
    {
        public AboutMappingProfile()
        {
            CreateMap<ResultAboutDto, About>().ReverseMap()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<AboutImageUrlResolver>());
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultAboutTranslationDto, AboutTranslation>().ReverseMap();
            CreateMap<UpdateAboutTranslationDto, AboutTranslation>().ReverseMap();
        }
    }
}
