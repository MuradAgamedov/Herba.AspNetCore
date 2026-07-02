using AutoMapper;
using Herba.Dtos.Analysis.Item;
using Herba.Dtos.Analysis.Translation;
using Herba.Entities.Analysis;

namespace Herba.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<ResultAnalysisDto, Analysis>().ReverseMap().ForMember(dest => dest.IconUrl, opt => opt.MapFrom<AnalysisIconUrlResolver<ResultAnalysisDto>>());
            CreateMap<CreateAnalysisDto, Analysis>().ReverseMap();
            CreateMap<UpdateAnalysisDto, Analysis>().ReverseMap();
            CreateMap<GetByIdAnalysisDto, Analysis>().ReverseMap().ForMember(dest => dest.IconUrl, opt => opt.MapFrom<AnalysisIconUrlResolver<GetByIdAnalysisDto>>());
            CreateMap<AnalysisFilterDto, Analysis>().ReverseMap();

            CreateMap<ResultAnalysisTranslationDto, AnalysisTranslation>().ReverseMap();
            CreateMap<CreateAnalysisTranslationDto, AnalysisTranslation>().ReverseMap();
            CreateMap<UpdateAnalysisTranslationDto, AnalysisTranslation>().ReverseMap();
        }
    }
}
