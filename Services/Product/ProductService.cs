using Herba.Dtos.Product.Item;
using Herba.Dtos.Common;
using Herba.Repositories.Product;

namespace Herba.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PaginatedResultDto<ResultProductDto>> GetAsync(ProductFilterDto dto)
        {
            return await _productRepository.GetAsync(dto);
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            await _productRepository.CreateAsync(dto);
        }

        public async Task<bool?> UpdateAsync(int id, UpdateProductDto dto)
        {
            return await _productRepository.UpdateAsync(id, dto);
        }

        public async Task<GetByIdProductDto?> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            return await _productRepository.DeleteRangeAsync(ids);
        }
    }
}
