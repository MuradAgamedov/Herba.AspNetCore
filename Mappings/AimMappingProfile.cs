using AutoMapper;
using Herba.Dtos.Aim.Item;
using Herba.Dtos.Aim.Translation;
using Herba.Entities.Aim;

namespace Herba.Mappings
{
    public class AimMappingProfile : Profile
    {
        public AimMappingProfile()
        {
            CreateMap<ResultAimDto, Aim>().ReverseMap().ForMember(dest => dest.IconUrl, opt => opt.MapFrom<AimIconUrlResolver>());
            CreateMap<CreateAimDto, Aim>().ReverseMap();
            CreateMap<UpdateAimDto, Aim>().ReverseMap();
            CreateMap<GetByIdAimDto, Aim>().ReverseMap();
            CreateMap<AimFilterDto, Aim>().ReverseMap();

            CreateMap<ResultAimTranslationDto, AimTranslation>().ReverseMap();
            CreateMap<CreateAimTranslationDto, AimTranslation>().ReverseMap();
            CreateMap<UpdateAimTranslationDto, AimTranslation>().ReverseMap();
        }
    }
}
