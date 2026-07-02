using Herba.Dtos.Analysis.Item;
using Herba.Dtos.Common;

namespace Herba.Services.Analysis
{
    public interface IAnalysisService
    {
        Task<PaginatedResultDto<ResultAnalysisDto>> GetAsync(AnalysisFilterDto dto);
        Task CreateAsync(CreateAnalysisDto dto);
        Task<bool?> UpdateAsync(int id, UpdateAnalysisDto dto);
        Task<GetByIdAnalysisDto?> GetById(int id);
        Task<bool?> DeleteAsync(int id);
        Task<bool?> DeleteRangeAsync(List<int> ids);
    }
}
