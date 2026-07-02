using Herba.Dtos.ProductCategory.Item;
using Herba.Dtos.Common;
using Herba.Repositories.ProductCategory;

namespace Herba.Services.ProductCategory
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<PaginatedResultDto<ResultProductCategoryDto>> GetAllAsync(ProductCategoryFilterDto dto)
        {
            return await _productCategoryRepository.GetAllAsync(dto);
        }

        public async Task CreateAsync(CreateProductCategoryDto dto)
        {
            await _productCategoryRepository.CreateAsync(dto);
        }

        public async Task<bool?> UpdateAsync(int id, UpdateProductCategoryDto dto)
        {
            return await _productCategoryRepository.UpdateAsync(id, dto);
        }

        public async Task<GetByIdProductCategoryDto?> GetById(int id)
        {
            return await _productCategoryRepository.GetById(id);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await _productCategoryRepository.DeleteAsync(id);
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            return await _productCategoryRepository.DeleteRangeAsync(ids);
        }
    }
}
