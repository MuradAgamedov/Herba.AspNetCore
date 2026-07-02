using Herba.Dtos.ProductCategory.Item;
using Herba.Services.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] ProductCategoryFilterDto dto)
        {
            var result = await _productCategoryService.GetAllAsync(dto);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateProductCategoryDto dto)
        {
            await _productCategoryService.CreateAsync(dto);
            return Ok("Məhsul kateqoriyası uğurla əlavə edildi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateProductCategoryDto dto)
        {
            var result = await _productCategoryService.UpdateAsync(id, dto);
            if (result == null)
            {
                return NotFound("Məhsul kateqoriyası tapılmadı");
            }
            return Ok("Məhsul kateqoriyası uğurla yeniləndi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductCategory(int id)
        {
            var result = await _productCategoryService.GetById(id);
            if (result == null)
            {
                return NotFound("Məhsul kateqoriyası tapılmadı");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productCategoryService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound("Məhsul kateqoriyası tapılmadı");
            }
            return Ok("Məhsul kateqoriyası uğurla silindi");
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteRangeAsync([FromQuery] List<int> ids)
        {
            var result = await _productCategoryService.DeleteRangeAsync(ids);
            if (result == null)
            {
                return NotFound("Məhsul kateqoriyalarından heç biri tapılmadı");
            }
            return Ok("Seçdiyiniz məhsul kateqoriyaları uğurla silindi");
        }
    }
}
