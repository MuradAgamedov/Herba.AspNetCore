using Herba.Dtos.Product.Item;
using Herba.Services.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] ProductFilterDto dto)
        {
            var result = await _productService.GetAsync(dto);
            return Ok(result);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateProductDto dto)
        {
            await _productService.CreateAsync(dto);
            return Ok("Məhsul uğurla əlavə edildi");
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateProductDto dto)
        {
            var result = await _productService.UpdateAsync(id, dto);
            if (result == null)
            {
                return NotFound("Məhsul tapılmadı");
            }
            return Ok("Məhsul uğurla yeniləndi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var result = await _productService.GetById(id);
            if (result == null)
            {
                return NotFound("Məhsul tapılmadı");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound("Məhsul tapılmadı");
            }
            return Ok("Məhsul uğurla silindi");
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteRangeAsync([FromQuery] List<int> ids)
        {
            var result = await _productService.DeleteRangeAsync(ids);
            if (result == null)
            {
                return NotFound("Məhsullardan heç biri tapılmadı");
            }
            return Ok("Seçdiyiniz məhsullar uğurla silindi");
        }
    }
}
