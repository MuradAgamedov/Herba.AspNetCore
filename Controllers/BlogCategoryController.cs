using Herba.Dtos.BlogCategory.Category;
using Herba.Dtos.Common;
using Herba.Repositories.BlogCategory;
using Herba.Services.BlogCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BlogCategoryController : ControllerBase
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public BlogCategoryController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] BlogCategoryFilterDto dto)
        {
            var result = await _blogCategoryService.GetAllAsync(dto);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateBlogCategoryDto dto)
        {
            await _blogCategoryService.CreateAsync(dto);
            return Ok("Bloq kateqoriyası uğurla əlavə edildi");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateBlogCategoryDto dto)
        {
            var result = await _blogCategoryService.UpdateAsync(id, dto);
            if (result == null)
            {
                return NotFound("Bloq kateqoriyası tapılmadı");
            }
            return Ok("Bloq kateqoriyası uğurla yeniləndi");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBlogCategory(int id)
        {
            var result = await _blogCategoryService.GetById(id);
            if (result == null)
            {
                return NotFound("Bloq kateqoriyası tapılmadı");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _blogCategoryService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound("Bloq kateqoriyası tapılmadı");
            }
            return Ok("Bloq kateqoriyası uğurla silindi");
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteRangeAsync([FromQuery] List<int> ids)
        {
            var result = await _blogCategoryService.DeleteRangeAsync(ids);
            if (result == null)
            {
                return NotFound("Bloq kateqoriyalarindan heç biri də tapılmadı");
            }
            return Ok("Seçdiyiniz bloq kateqoriyaları uğurla silindi");
        }
    }
}
