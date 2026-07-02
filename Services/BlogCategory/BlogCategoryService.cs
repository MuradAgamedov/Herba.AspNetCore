using Herba.Dtos.BlogCategory.Category;
using Herba.Dtos.Category;
using Herba.Dtos.Common;
using Herba.Repositories.BlogCategory;

namespace Herba.Services.BlogCategory
{
    public class BlogCategoryService : IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task<PaginatedResultDto<ResultBlogCategoryDto>> GetAllAsync(BlogCategoryFilterDto dto)
        {
            return await _blogCategoryRepository.GetAllAsync(dto);
        }


        public async Task CreateAsync(CreateBlogCategoryDto dto)
        {
            await _blogCategoryRepository.CreateAsync(dto);
        }


        public async Task<bool?> UpdateAsync(int id, UpdateBlogCategoryDto dto)
        {
            return await _blogCategoryRepository.UpdateAsync(id, dto);
        }

        public async Task<GetByIdBlogCategoryDto?> GetById(int id)
        {
            return await _blogCategoryRepository.GetById(id);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await _blogCategoryRepository.DeleteAsync(id);
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            return await _blogCategoryRepository.DeleteRangeAsync(ids);
        }
    }
}
