using Herba.Dtos.Auth;

namespace Herba.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<string?> LoginAsnycAsync(LoginDto dto);
    }
}
