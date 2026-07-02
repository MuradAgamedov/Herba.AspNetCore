using Herba.Dtos.Blog.Post;
using Herba.Dtos.Common;
using Herba.Repositories.Blog;

namespace Herba.Services.Blog
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<PaginatedResultDto<ResultBlogDto>> GetAsync(BlogFilterDto dto)
        {
            return await _blogRepository.GetAsync(dto);
        }
        public async Task CreateAsync(CreateBlogDto dto)
        {
            await _blogRepository.CreateAsync(dto);
        }

        public async Task<bool?> UpdateAsync(int id, UpdateBlogDto dto)
        {
            return await _blogRepository.UpdateAsync(id, dto);
        }

        public async Task<GetByIdBlogDto?> GetById(int id)
        {
            return await _blogRepository.GetById(id);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await _blogRepository.DeleteAsync(id);
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            return await _blogRepository.DeleteRangeAsync(ids);
        }
    }
}
