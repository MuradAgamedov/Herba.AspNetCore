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
            CreateMap<ResultBlogDto, Blog>().ReverseMap().ForMember(dest=>dest.ImageUrl, opt=>opt.MapFrom<BlogImageUrlResolver>());
            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            CreateMap<GetByIdBlogDto, Blog>().ReverseMap();
            CreateMap<BlogFilterDto, Blog>().ReverseMap();

            CreateMap<ResultBlogTranslationDto, BlogTranslation>().ReverseMap();
            CreateMap<CreateBlogTranslationDto, BlogTranslation>().ReverseMap();
            CreateMap<UpdateBlogTranslationDto, BlogTranslation>().ReverseMap();
        }
    }
}
