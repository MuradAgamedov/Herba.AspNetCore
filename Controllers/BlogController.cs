using Herba.Dtos.Blog.Post;
using Herba.Services.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] BlogFilterDto dto)
        {
            var result = await _blogService.GetAsync(dto);
            return Ok(result);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateAsync([FromForm] CreateBlogDto dto)
        {
            await _blogService.CreateAsync(dto);
            return Ok("Bloq uğurla əlavə edildi");
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] UpdateBlogDto dto)
        {
            var result = await _blogService.UpdateAsync(id, dto);
            if (result == null)
            {
                return NotFound("Bloq tapılmadı");
            }
            return Ok("Bloq uğurla yeniləndi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdBlog(int id)
        {
            var result = await _blogService.GetById(id);
            if (result == null)
            {
                return NotFound("Bloq tapılmadı");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _blogService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound("Bloq tapılmadı");
            }
            return Ok("Bloq uğurla silindi");
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteRangeAsync([FromQuery] List<int> ids)
        {
            var result = await _blogService.DeleteRangeAsync(ids);
            if (result == null)
            {
                return NotFound("Bloqlardan heç biri tapılmadı");
            }
            return Ok("Seçdiyiniz bloqlar uğurla silindi");
        }
    }
}
