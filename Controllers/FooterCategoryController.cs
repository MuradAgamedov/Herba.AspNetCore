using Herba.Dtos.FooterCategory.Item;
using Herba.Services.FooterCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FooterCategoryController : ControllerBase
    {
        private readonly IFooterCategoryService _footerCategoryService;

        public FooterCategoryController(IFooterCategoryService footerCategoryService)
        {
            _footerCategoryService = footerCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] FooterCategoryFilterDto dto)
        {
            var result = await _footerCategoryService.GetAsync(dto);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateFooterCategoryDto dto)
        {
            await _footerCategoryService.CreateAsync(dto);
            return Ok("Kateqoriya footer siyahısına əlavə edildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _footerCategoryService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound("Qeyd tapılmadı");
            }
            return Ok("Kateqoriya footer siyahısından silindi");
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteRangeAsync([FromQuery] List<int> ids)
        {
            var result = await _footerCategoryService.DeleteRangeAsync(ids);
            if (result == null)
            {
                return NotFound("Heç bir qeyd tapılmadı");
            }
            return Ok("Seçdiyiniz kateqoriyalar siyahıdan silindi");
        }
    }
}
