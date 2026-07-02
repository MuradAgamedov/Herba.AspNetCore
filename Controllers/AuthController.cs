using Herba.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Herba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Dtos.Auth.LoginDto dto)
        {
            var token = await _authService.LoginAsnycAsync(dto);
            if (token == null)
            {
                return Unauthorized("Giriş məlumatları yanlışdır!");
            }
            return Ok(new { 
                Message = "Giriş uğurludur",
                token });
        }
    }
}
