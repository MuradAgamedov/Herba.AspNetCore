using Herba.Dtos.Hero.Item;

namespace Herba.Services.Hero
{
    public interface IHeroService
    {
        Task<ResultHeroDto?> GetAsync();
        Task<bool?> UpdateAsync(UpdateHeroDto dto);
    }
}
