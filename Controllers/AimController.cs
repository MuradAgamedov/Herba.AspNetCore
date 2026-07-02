using Herba.Dtos.Aim.Item;
using Herba.Services.Aim;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AimController : ControllerBase
    {
        private readonly IAimService _aimService;

        public AimController(IAimService aimService)
        {
            _aimService = aimService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] AimFilterDto dto)
        {
            var result = await _aimService.GetAsync(dto);
            return Ok(result);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateAimDto dto)
        {
            await _aimService.CreateAsync(dto);
            return Ok("Məqsəd uğurla əlavə edildi");
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateAimDto dto)
        {
            var result = await _aimService.UpdateAsync(id, dto);
            if (result == null)
            {
                return NotFound("Məqsəd tapılmadı");
            }
            return Ok("Məqsəd uğurla yeniləndi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAim(int id)
        {
            var result = await _aimService.GetById(id);
            if (result == null)
            {
                return NotFound("Məqsəd tapılmadı");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _aimService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound("Məqsəd tapılmadı");
            }
            return Ok("Məqsəd uğurla silindi");
        }

        [HttpDelete("{ids}")]
        public async Task<IActionResult> DeleteRangeAsync(List<int> ids)
        {
            var result = await _aimService.DeleteRangeAsync(ids);
            if (result == null)
            {
                return NotFound("Məqsədlərdən heç biri tapılmadı");
            }
            return Ok("Seçdiyiniz məqsədlər uğurla silindi");
        }
    }
}
