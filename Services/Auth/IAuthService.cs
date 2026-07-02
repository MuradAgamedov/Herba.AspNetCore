using Herba.Dtos.Auth;

namespace Herba.Services.Auth
{
    public interface IAuthService
    {
        Task<string?> LoginAsnycAsync(LoginDto dto);
    }
}
