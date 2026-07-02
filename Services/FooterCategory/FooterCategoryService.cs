using Herba.Dtos.FooterCategory.Item;
using Herba.Dtos.Common;
using Herba.Repositories.FooterCategory;

namespace Herba.Services.FooterCategory
{
    public class FooterCategoryService : IFooterCategoryService
    {
        private readonly IFooterCategoryRepository _footerCategoryRepository;

        public FooterCategoryService(IFooterCategoryRepository footerCategoryRepository)
        {
            _footerCategoryRepository = footerCategoryRepository;
        }

        public async Task<PaginatedResultDto<ResultFooterCategoryDto>> GetAsync(FooterCategoryFilterDto dto)
        {
            return await _footerCategoryRepository.GetAsync(dto);
        }

        public async Task CreateAsync(CreateFooterCategoryDto dto)
        {
            await _footerCategoryRepository.CreateAsync(dto);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await _footerCategoryRepository.DeleteAsync(id);
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            return await _footerCategoryRepository.DeleteRangeAsync(ids);
        }
    }
}
