using Herba.Dtos.FeaturedProduct.Item;
using Herba.Dtos.Common;
using Herba.Repositories.FeaturedProduct;

namespace Herba.Services.FeaturedProduct
{
    public class FeaturedProductService : IFeaturedProductService
    {
        private readonly IFeaturedProductRepository _featuredProductRepository;

        public FeaturedProductService(IFeaturedProductRepository featuredProductRepository)
        {
            _featuredProductRepository = featuredProductRepository;
        }

        public async Task<PaginatedResultDto<ResultFeaturedProductDto>> GetAsync(FeaturedProductFilterDto dto)
        {
            return await _featuredProductRepository.GetAsync(dto);
        }

        public async Task CreateAsync(CreateFeaturedProductDto dto)
        {
            await _featuredProductRepository.CreateAsync(dto);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await _featuredProductRepository.DeleteAsync(id);
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            return await _featuredProductRepository.DeleteRangeAsync(ids);
        }
    }
}
