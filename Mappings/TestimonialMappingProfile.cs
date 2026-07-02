using AutoMapper;
using Herba.Dtos.Testimonial.Item;
using Herba.Dtos.Testimonial.Translation;
using Herba.Entities.Testimonial;

namespace Herba.Mappings
{
    public class TestimonialMappingProfile : Profile
    {
        public TestimonialMappingProfile()
        {
            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<GetByIdTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<TestimonialFilterDto, Testimonial>().ReverseMap();

            CreateMap<ResultTestimonialTranslationDto, TestimonialTranslation>().ReverseMap();
            CreateMap<UpdateTestimonialTranslationDto, TestimonialTranslation>().ReverseMap();
        }
    }
}
