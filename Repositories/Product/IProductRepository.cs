using Herba.Dtos.Product.Item;
using Herba.Dtos.Common;

namespace Herba.Repositories.Product
{
    public interface IProductRepository
    {
        Task<PaginatedResultDto<ResultProductDto>> GetAsync(ProductFilterDto dto);
        Task CreateAsync(CreateProductDto dto);
        Task<bool?> UpdateAsync(int id, UpdateProductDto dto);
        Task<GetByIdProductDto?> GetById(int id);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
