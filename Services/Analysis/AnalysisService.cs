using Herba.Dtos.Analysis.Item;
using Herba.Dtos.Common;
using Herba.Repositories.Analysis;

namespace Herba.Services.Analysis
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IAnalysisRepository _analysisRepository;

        public AnalysisService(IAnalysisRepository analysisRepository)
        {
            _analysisRepository = analysisRepository;
        }

        public async Task<PaginatedResultDto<ResultAnalysisDto>> GetAsync(AnalysisFilterDto dto)
        {
            return await _analysisRepository.GetAsync(dto);
        }

        public async Task CreateAsync(CreateAnalysisDto dto)
        {
            await _analysisRepository.CreateAsync(dto);
        }

        public async Task<bool?> UpdateAsync(int id, UpdateAnalysisDto dto)
        {
            return await _analysisRepository.UpdateAsync(id, dto);
        }

        public async Task<GetByIdAnalysisDto?> GetById(int id)
        {
            return await _analysisRepository.GetById(id);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await _analysisRepository.DeleteAsync(id);
        }

        public async Task<bool?> DeleteRangeAsync(List<int> ids)
        {
            return await _analysisRepository.DeleteRangeAsync(ids);
        }
    }
}
