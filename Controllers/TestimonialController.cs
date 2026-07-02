using Herba.Dtos.Testimonial.Item;
using Herba.Services.Testimonial;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] TestimonialFilterDto dto)
        {
            var result = await _testimonialService.GetAllAsync(dto);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateTestimonialDto dto)
        {
            await _testimonialService.CreateAsync(dto);
            return Ok("Rəy uğurla əlavə edildi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateTestimonialDto dto)
        {
            var result = await _testimonialService.UpdateAsync(id, dto);
            if (result == null)
            {
                return NotFound("Rəy tapılmadı");
            }
            return Ok("Rəy uğurla yeniləndi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTestimonial(int id)
        {
            var result = await _testimonialService.GetById(id);
            if (result == null)
            {
                return NotFound("Rəy tapılmadı");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _testimonialService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound("Rəy tapılmadı");
            }
            return Ok("Rəy uğurla silindi");
        }

        [HttpDelete("range")]
        public async Task<IActionResult> DeleteRangeAsync([FromQuery] List<int> ids)
        {
            var result = await _testimonialService.DeleteRangeAsync(ids);
            if (result == null)
            {
                return NotFound("Rəylərdən heç biri tapılmadı");
            }
            return Ok("Seçdiyiniz rəylər uğurla silindi");
        }
    }
}
