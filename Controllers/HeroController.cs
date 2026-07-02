using Herba.Dtos.Hero.Item;
using Herba.Services.Hero;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;

        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _heroService.GetAsync();
            if (result == null)
            {
                return NotFound("Hero məlumatı tapılmadı");
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateHeroDto dto)
        {
            var result = await _heroService.UpdateAsync(dto);
            if (result == null)
            {
                return NotFound("Hero məlumatı tapılmadı");
            }
            return Ok("Hero məlumatı uğurla yeniləndi");
        }
    }
}
