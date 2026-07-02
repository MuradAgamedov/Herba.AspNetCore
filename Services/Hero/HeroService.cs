using Herba.Dtos.Hero.Item;
using Herba.Repositories.Hero;

namespace Herba.Services.Hero
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;

        public HeroService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public async Task<ResultHeroDto?> GetAsync()
        {
            return await _heroRepository.GetAsync();
        }

        public async Task<bool?> UpdateAsync(UpdateHeroDto dto)
        {
            return await _heroRepository.UpdateAsync(dto);
        }
    }
}
