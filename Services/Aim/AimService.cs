using Herba.Dtos.Aim.Item;
using Herba.Dtos.Common;
using Herba.Repositories.Aim;

namespace Herba.Services.Aim
{
    public class AimService : IAimService
    {
        private readonly IAimRepository _aimRepository;

        public AimService(IAimRepository aimRepository)
        {
            _aimRepository = aimRepository;
        }

        public async Task<PaginatedResultDto<ResultAimDto>> GetAsync(AimFilterDto dto)
        {
            return await _aimRepository.GetAsync(dto);
        }

        public async Task CreateAsync(CreateAimDto dto)
        {
            await _aimRepository.CreateAsync(dto);
        }

        public async Task<bool?> UpdateAsync(int id, UpdateAimDto dto)
        {
            return await _aimRepository.UpdateAsync(id, dto);
        }

        public async Task<GetByIdAimDto?> GetById(int id)
        {
            return await _aimRepository.GetById(id);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await _aimRepository.DeleteAsync(id);
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            return await _aimRepository.DeleteRangeAsync(ids);
        }
    }
}
