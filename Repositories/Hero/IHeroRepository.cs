using Herba.Dtos.Hero.Item;

namespace Herba.Repositories.Hero
{
    public interface IHeroRepository
    {
        Task<ResultHeroDto?> GetAsync();
        Task<bool?> UpdateAsync(UpdateHeroDto dto);
    }
}
