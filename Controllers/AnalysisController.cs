using Herba.Dtos.Analysis.Item;
using Herba.Services.Analysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;

        public AnalysisController(IAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] AnalysisFilterDto dto)
        {
            var result = await _analysisService.GetAsync(dto);
            return Ok(result);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateAnalysisDto dto)
        {
            await _analysisService.CreateAsync(dto);
            return Ok("Analiz uğurla əlavə edildi");
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateAnalysisDto dto)
        {
            var result = await _analysisService.UpdateAsync(id, dto);
            if (result == null)
            {
                return NotFound("Analiz tapılmadı");
            }
            return Ok("Analiz uğurla yeniləndi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAnalysis(int id)
        {
            var result = await _analysisService.GetById(id);
            if (result == null)
            {
                return NotFound("Analiz tapılmadı");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _analysisService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound("Analiz tapılmadı");
            }
            return Ok("Analiz uğurla silindi");
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteRangeAsync([FromQuery] List<int> ids)
        {
            var result = await _analysisService.DeleteRangeAsync(ids);
            if (result == null)
            {
                return NotFound("Analizlərdən heç biri tapılmadı");
            }
            return Ok("Seçdiyiniz analizlər uğurla silindi");
        }
    }
}
