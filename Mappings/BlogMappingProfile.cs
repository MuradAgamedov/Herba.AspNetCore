using AutoMapper;
using Herba.Dtos.Blog.Post;
using Herba.Dtos.Blog.Translation;
using Herba.Dtos.BlogCategory.Category;
using Herba.Dtos.BlogCategory.Translation;
using Herba.Dtos.Category;
using Herba.Entities.Blog;
using Herba.Entities.BlogCategory;

namespace Herba.Mappings
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog, ResultBlogDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<BlogImageUrlResolver<ResultBlogDto>>());

            CreateMap<Blog, GetByIdBlogDto>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<BlogImageUrlResolver<GetByIdBlogDto>>());

            CreateMap<CreateBlogDto, Blog>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());

            CreateMap<UpdateBlogDto, Blog>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());

            CreateMap<BlogFilterDto, Blog>().ReverseMap();

            CreateMap<BlogTranslation, ResultBlogTranslationDto>();
            CreateMap<CreateBlogTranslationDto, BlogTranslation>();
            CreateMap<UpdateBlogTranslationDto, BlogTranslation>();
        }
    }
}