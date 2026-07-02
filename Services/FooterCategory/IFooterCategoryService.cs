using Herba.Dtos.FooterCategory.Item;
using Herba.Dtos.Common;

namespace Herba.Services.FooterCategory
{
    public interface IFooterCategoryService
    {
        Task<PaginatedResultDto<ResultFooterCategoryDto>> GetAsync(FooterCategoryFilterDto dto);
        Task CreateAsync(CreateFooterCategoryDto dto);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
