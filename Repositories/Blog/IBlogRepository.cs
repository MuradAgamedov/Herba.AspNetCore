using Herba.Dtos.Blog.Post;
using Herba.Dtos.Common;

namespace Herba.Repositories.Blog
{
    public interface IBlogRepository
    {
        Task<PaginatedResultDto<ResultBlogDto>> GetAsync(BlogFilterDto dto);
        Task CreateAsync(CreateBlogDto dto);
        Task<bool?> UpdateAsync(int id, UpdateBlogDto dto);
        Task<GetByIdBlogDto?> GetById(int id);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
