using Herba.Dtos.About.Item;
using Herba.Repositories.About;

namespace Herba.Services.About
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<ResultAboutDto?> GetAsync()
        {
            return await _aboutRepository.GetAsync();
        }

        public async Task<bool?> UpdateAsync(UpdateAboutDto dto)
        {
            return await _aboutRepository.UpdateAsync(dto);
        }
    }
}
