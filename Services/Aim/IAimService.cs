using Herba.Dtos.Aim.Item;
using Herba.Dtos.Common;

namespace Herba.Services.Aim
{
    public interface IAimService
    {
        Task<PaginatedResultDto<ResultAimDto>> GetAsync(AimFilterDto dto);
        Task CreateAsync(CreateAimDto dto);
        Task<bool?> UpdateAsync(int id, UpdateAimDto dto);
        Task<GetByIdAimDto?> GetById(int id);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
