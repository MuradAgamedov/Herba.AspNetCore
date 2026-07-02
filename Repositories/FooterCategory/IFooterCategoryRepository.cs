using Herba.Dtos.FooterCategory.Item;
using Herba.Dtos.Common;

namespace Herba.Repositories.FooterCategory
{
    public interface IFooterCategoryRepository
    {
        Task<PaginatedResultDto<ResultFooterCategoryDto>> GetAsync(FooterCategoryFilterDto dto);
        Task CreateAsync(CreateFooterCategoryDto dto);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
