using AutoMapper;
using Herba.Dtos.Hero.Item;
using Herba.Dtos.Hero.Translation;
using Herba.Entities.Hero;

namespace Herba.Mappings
{
    public class HeroMappingProfile : Profile
    {
        public HeroMappingProfile()
        {
            CreateMap<ResultHeroDto, Hero>().ReverseMap();
            CreateMap<UpdateHeroDto, Hero>().ReverseMap();

            CreateMap<ResultHeroTranslationDto, HeroTranslation>().ReverseMap();
            CreateMap<UpdateHeroTranslationDto, HeroTranslation>().ReverseMap();
        }
    }
}
