using Herba.Dtos.FeaturedProduct.Item;
using Herba.Dtos.Common;

namespace Herba.Services.FeaturedProduct
{
    public interface IFeaturedProductService
    {
        Task<PaginatedResultDto<ResultFeaturedProductDto>> GetAsync(FeaturedProductFilterDto dto);
        Task CreateAsync(CreateFeaturedProductDto dto);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
