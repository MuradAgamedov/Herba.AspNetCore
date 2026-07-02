using Herba.Dtos.FeaturedProduct.Item;
using Herba.Services.FeaturedProduct;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturedProductController : ControllerBase
    {
        private readonly IFeaturedProductService _featuredProductService;

        public FeaturedProductController(IFeaturedProductService featuredProductService)
        {
            _featuredProductService = featuredProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] FeaturedProductFilterDto dto)
        {
            var result = await _featuredProductService.GetAsync(dto);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateFeaturedProductDto dto)
        {
            await _featuredProductService.CreateAsync(dto);
            return Ok("Məhsul ən çox seçilənlər siyahısına əlavə edildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _featuredProductService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound("Qeyd tapılmadı");
            }
            return Ok("Məhsul ən çox seçilənlər siyahısından silindi");
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteRangeAsync([FromQuery] List<int> ids)
        {
            var result = await _featuredProductService.DeleteRangeAsync(ids);
            if (result == null)
            {
                return NotFound("Heç bir qeyd tapılmadı");
            }
            return Ok("Seçdiyiniz məhsullar siyahıdan silindi");
        }
    }
}
