using Herba.Dtos.BlogCategory.Category;
using Herba.Dtos.Category;
using Herba.Dtos.Common;

namespace Herba.Services.BlogCategory
{
    public interface IBlogCategoryService
    {
        Task<PaginatedResultDto<ResultBlogCategoryDto>> GetAllAsync(BlogCategoryFilterDto dto);
        Task CreateAsync(CreateBlogCategoryDto dto);
        Task<bool?> UpdateAsync(int id, UpdateBlogCategoryDto dto);
        Task<GetByIdBlogCategoryDto?> GetById(int id);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
