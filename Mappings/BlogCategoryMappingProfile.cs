using AutoMapper;
using Herba.Dtos.BlogCategory.Category;
using Herba.Dtos.BlogCategory.Translation;
using Herba.Dtos.Category;
using Herba.Entities.BlogCategory;

namespace Herba.Mappings
{
    public class BlogCategoryMappingProfile : Profile
    {
        public BlogCategoryMappingProfile()
        {
            CreateMap<ResultBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<CreateBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<UpdateBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<GetByIdBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<BlogCategoryFilterDto, BlogCategory>().ReverseMap();


            CreateMap<ResultBlogCategoryTranslationDto, BlogCategoryTranslation>().ReverseMap();
            CreateMap<CreateBlogCategoryTranslationDto, BlogCategoryTranslation>().ReverseMap();
            CreateMap<UpdateBlogCategoryTranslationDto, BlogCategoryTranslation>().ReverseMap();
        }
    }
}
