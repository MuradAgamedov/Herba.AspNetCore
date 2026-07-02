using Herba.Dtos.Auth;
using Herba.Repositories.Auth;

namespace Herba.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<string?> LoginAsnycAsync(LoginDto dto)
        {
            return _authRepository.LoginAsnycAsync(dto);
        }
    }
}
