using Herba.Dtos.About.Item;
using Herba.Services.About;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _aboutService.GetAsync();
            if (result == null)
            {
                return NotFound("Haqqımızda məlumatı tapılmadı");
            }
            return Ok(result);
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateAboutDto dto)
        {
            var result = await _aboutService.UpdateAsync(dto);
            if (result == null)
            {
                return NotFound("Haqqımızda məlumatı tapılmadı");
            }
            return Ok("Haqqımızda məlumatı uğurla yeniləndi");
        }
    }
}
