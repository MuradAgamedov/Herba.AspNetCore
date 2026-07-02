using Herba.Dtos.ProductCategory.Item;
using Herba.Dtos.Common;

namespace Herba.Repositories.ProductCategory
{
    public interface IProductCategoryRepository
    {
        Task<PaginatedResultDto<ResultProductCategoryDto>> GetAllAsync(ProductCategoryFilterDto dto);
        Task CreateAsync(CreateProductCategoryDto dto);
        Task<bool?> UpdateAsync(int id, UpdateProductCategoryDto dto);
        Task<GetByIdProductCategoryDto?> GetById(int id);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
